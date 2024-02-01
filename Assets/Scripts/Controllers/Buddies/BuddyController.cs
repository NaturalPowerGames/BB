using UnityEngine;

namespace BB.Buddies
{
	public class BuddyController : MonoBehaviour
	{
		private BuddyDataUIController dataUI;
		private Buddy buddy;

		private void Initialize(Buddy buddy)
		{
			dataUI = GetComponent<BuddyDataUIController>();
			dataUI.Initialize(buddy);
			this.buddy = buddy;
		}
	}
}