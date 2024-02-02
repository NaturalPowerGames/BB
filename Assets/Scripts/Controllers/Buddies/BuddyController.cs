using UnityEngine;
using UnityEngine.EventSystems;

namespace BB.Buddies
{
	public class BuddyController : MonoBehaviour, IPointerDownHandler
	{
		private Buddy buddy;

		public void OnPointerDown(PointerEventData eventData)
		{
			BuddyEvents.OnBuddySelected?.Invoke(buddy);
		}

		private void Initialize(Buddy buddy)
		{			
			this.buddy = buddy;
		}
	}
}