using BB.TimeManagement;
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
		private bool isBusy = false;
		[SerializeField]
		public List<Need> ResourcesNeeded = new List<Need>();

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
			if (urgent && !ResourcesNeeded.Contains(need))
			{
				ResourcesNeeded.Add(need);
				if(!isBusy)
				{
					performNeedHealAction(need);

                }
			}
			//ResourceEvents.OnStopCollecting?.Invoke(TickTime.Large);
		}

		private void performNeedHealAction(Need need)
		{
            BuddyEvents.OnBuddyNeedsStation?.Invoke(need, transform.position, GoToStation);
        }

		private void GoToStation(IInteractable station)
		{
			navigationController.MoveTo(station.GetLocation(),
				() =>
				{
					buddy.OnNeedFullyRecovered += OnNeedFullyRecovered;
					station.Interact(buddy);
					isBusy = true;
					currentInteraction = station;
				});
		}

		private void OnNeedFullyRecovered(Need need)
		{
			currentInteraction?.StopInteraction(buddy);
			currentInteraction = null;
            isBusy = false;
			ResourcesNeeded.Remove(need);
            buddy.OnNeedFullyRecovered -= OnNeedFullyRecovered;

			if(ResourcesNeeded.Count > 0)
			{
				BuddyEvents.OnBuddyNeedsStation?.Invoke(ResourcesNeeded[0], transform.position, GoToStation);
            }
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