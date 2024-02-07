using BB.Buddies;
using System.Collections.Generic;
using UnityEngine;

namespace BB.Hub
{
	public class HealingStationController : MonoBehaviour, IInteractable
	{
		public float healRate;
		public Need healedNeed;
		private List<Buddy> buddiesHealing = new List<Buddy>();

		public Vector3 GetLocation()
		{
			return transform.position; //will be a specified transform location, not the object's, in the future
		}

		public void Interact<T>(T Interactor)
		{
			Buddy buddy = Interactor as Buddy;
			buddiesHealing.Add(buddy);
		}
	}
}