using BB.Buddies;
using System.Collections.Generic;
using UnityEngine;

namespace BB.Stations
{
    [System.Serializable]
    public class Station
    {
        private float resourceRate;
        private TaskType taskType;
        private ResourceType resourceType;
        private Need need;
        private float needRate;
        [SerializeField]
        private List<Buddy> buddiesWorking = new List<Buddy>();

        public Need GetNeed()
        {
            return need;
        }

        public Station(Need need, float needRate)
        {
            this.need = need;
            this.needRate = needRate;
            resourceRate = 5;
        }

        public void AddBuddyToStation(Buddy buddy)
        {
            buddiesWorking.Add(buddy);
        }
        
        public void RemoveBuddyFromStation(Buddy buddy)
        {
            buddiesWorking.Remove(buddy);
        }

        public bool IsEmpty() //will be changed to account for number of slots in the station
        {
            Debug.Log("Station: " + need + " " + buddiesWorking.Count);
            return buddiesWorking.Count < 1;
        }

		public void HealNeed() 
		{
			var buddiesWorkingCopy = new List<Buddy>(buddiesWorking); //needs a rework
			foreach (var buddy in buddiesWorkingCopy)
			{
				buddy.HealNeed(need, resourceRate);
			}
			buddiesWorking = buddiesWorkingCopy;
		}
	}
}
