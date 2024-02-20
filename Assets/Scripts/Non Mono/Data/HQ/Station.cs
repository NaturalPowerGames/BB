using BB.Buddies;
using System.Collections.Generic;
using UnityEngine;

namespace BB.Stations
{
    [System.Serializable]
    public abstract class Station
    {
        protected float interactionBenefitRate;
        [SerializeField]
        protected List<Buddy> buddiesInteracting = new List<Buddy>(), buddiesToRemove = new List<Buddy>(), buddiesToAdd = new List<Buddy>();

        public void AddBuddyToStation(Buddy buddy)
        {
            buddiesToAdd.Add(buddy);
        }
        
        public void RemoveBuddyFromStation(Buddy buddy)
        {
            buddiesToRemove.Remove(buddy);
        }

        public bool IsEmpty() //will be changed to account for number of slots in the station
        {
            return buddiesInteracting.Count < 1;
        }

        public virtual void PerformInteractionEffect()
		{
            HandleBuddies();
		}

		public virtual void HandleBuddies()  //is there a better way? ugly
        {           
            foreach (var buddy in buddiesToAdd)
			{
                buddiesInteracting.Add(buddy);
			}

            buddiesToAdd.Clear();

            foreach (var buddy in buddiesToRemove)
            {
                buddiesInteracting.Remove(buddy);
            }

            buddiesToRemove.Clear();
        }
	}
}
