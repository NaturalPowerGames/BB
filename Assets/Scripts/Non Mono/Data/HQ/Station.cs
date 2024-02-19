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
        private GatheringType resourceType;
        private Need need;
        private float needRate;
        [SerializeField]
        private List<Buddy> buddiesWorking = new List<Buddy>(), buddiesToRemove = new List<Buddy>(), buddiesToAdd = new List<Buddy>();

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
            buddiesToAdd.Add(buddy);
        }
        
        public void RemoveBuddyFromStation(Buddy buddy)
        {
            buddiesToRemove.Remove(buddy);
        }

        public bool IsEmpty() //will be changed to account for number of slots in the station
        {
            Debug.Log("Station: " + need + " " + buddiesWorking.Count);
            return buddiesWorking.Count < 1;
        }

		public void HealNeedAndHandleLists()  //is there a better way? ugly
		{
			foreach (var buddy in buddiesWorking)
			{
				buddy.HealNeed(need, resourceRate);
			}

			foreach (var buddy in buddiesToAdd)
			{
                buddiesWorking.Add(buddy);
			}

            buddiesToAdd.Clear();

            foreach (var buddy in buddiesToRemove)
            {
                buddiesWorking.Remove(buddy);
            }

            buddiesToRemove.Clear();
        }
	}
}
