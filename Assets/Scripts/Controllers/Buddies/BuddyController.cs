using BB.TimeManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BB.Buddies
{
	public class BuddyController : MonoBehaviour, IPointerDownHandler, ITickListener
	{
		private Buddy buddy;

		public void OnPointerDown(PointerEventData eventData)
		{
			BuddyEvents.OnBuddySelected?.Invoke(buddy);
		}

		public void Initialize(Buddy buddy)
		{			
			this.buddy = buddy;
			SubscribeToTicks(TickTime.Large);
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