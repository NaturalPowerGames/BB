using BB.Buddies;
using System.Collections.Generic;
using UnityEngine;

namespace BB.Stations
{
    [System.Serializable]
    public class Station
    {
        public float resourceRate;
        public TaskType taskType;
        public ResourceType resourceType;
        public Need need;
        [SerializeField]
        private List<Buddy> buddiesWorking = new List<Buddy>(), buddiesToRemove = new List<Buddy>();


        public Station(Need need)
        {
            this.need = need;
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

        public bool isEmpty()
        {
            Debug.Log("Station: " + need + " " + buddiesWorking.Count);
            return buddiesWorking.Count < 1;
        }

        public void healBuddiesNeeds()
        {
            var buddiesWorkingCopy = new List<Buddy>(buddiesWorking);
            foreach (var buddy in buddiesWorkingCopy)
            {
                buddy.HealNeed(need, resourceRate);
            }
            buddiesWorking = buddiesWorkingCopy;

        }
    }
}
