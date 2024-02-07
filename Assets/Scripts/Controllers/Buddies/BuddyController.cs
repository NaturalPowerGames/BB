using BB.Hub;
using BB.TimeManagement;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BB.Buddies
{
	public class BuddyController : MonoBehaviour, IPointerDownHandler, ITickListener
	{
		private Buddy buddy;
		private NavigationController navigationController;

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
			buddy.OnNeedUrgent += OnNeedUrgent;
			SubscribeToTicks(TickTime.Large);
		}

		private void OnNeedUrgent(Need need)
		{
			BuddyEvents.OnClosestHealingStationRequested?.Invoke(need, transform.position, GoToStation);
		}

		private void GoToStation(IInteractable station)
		{
			navigationController.MoveTo(station.GetLocation(),
				() =>
				{
				});
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