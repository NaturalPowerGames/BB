using BB.Hub;
using BB.TimeManagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BB.Buddies
{
	public class BuddyController : MonoBehaviour, IPointerDownHandler, ITickListener
	{
		private Buddy buddy;
		private NavigationController navigationController;
		[SerializeField]
		private IInteractable currentInteraction;
		private bool isWorking = false;

		private void Awake()
		{
			navigationController = GetComponent<NavigationController>();

		}

		public void OnPointerDown(PointerEventData eventData)
		{
			BuddyEvents.OnBuddySelected?.Invoke(buddy);
		}

		public void Initialize(Buddy buddy)
		{
			this.buddy = buddy;
			this.buddy.OnNeedUrgencyChanged += OnNeedUrgencyChanged;
			SubscribeToTicks(TickTime.Large);
			GetComponentInChildren<BuddyActionDisplayController>().Initialize(buddy); //is this the right place? I guess?
		}

		private void OnNeedUrgencyChanged(Need need, bool urgent)
		{
			//here's where a queue comes in... this version will make the buddies go only to the latest need station if they have all the stuff in urgent at the same time
			//actionqueue :X?
			if (urgent)
			{
				BuddyEvents.OnClosestHealingStationRequested?.Invoke(need, transform.position, GoToStation);
				ResourceEvents.OnStopCollecting?.Invoke(TickTime.Large);
			}
			if (!isWorking && !urgent)
			{
				BuddyEvents.OnBuddyWantsToWork?.Invoke(ResourceType.Wood, transform.position, GoToWork);
			}
		}

		private void GoToStation(IInteractable station)
		{
			navigationController.MoveTo(station.GetLocation(),
				() =>
				{
					buddy.OnNeedFullyRecovered += OnNeedFullyRecovered;
					station.Interact(buddy);
					currentInteraction = station;
				});
		}
		private void GoToWork(IInteractable station)
		{
			navigationController.MoveTo(station.GetLocation(),
				() =>
				{
					station.Interact(buddy);
					currentInteraction = station;
				});
		}

		private void OnNeedFullyRecovered(Need need)
		{
			currentInteraction?.StopInteraction(buddy);
			currentInteraction = null;
			buddy.OnNeedFullyRecovered -= OnNeedFullyRecovered;
		}


		public void SubscribeToTicks(TickTime tickTime)
		{
			TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
		}

		public void OnTicked()
		{
			buddy.DecreaseAllNeeds();
        }

	}
}