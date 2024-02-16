using BB.Buddies;
using UnityEngine;
using BB.TimeManagement;
using BB.Stations;

namespace BB.Hub
{
    public class StationController : MonoBehaviour, IInteractable, ITickListener
    {
        private Station station;
        [SerializeField]
        private Transform navigationTargetsParent;
        [SerializeField]
        private Transform[] navigationTargets;

        public void SetupNavigationTargets()
        {
            navigationTargets = new Transform[navigationTargetsParent.childCount];
            for (int i = 0; i < navigationTargets.Length; i++)
            {
                navigationTargets[i] = navigationTargetsParent.GetChild(i);
            }
        }

        public Transform GetFirstFreeNavTarget()
        {
            return navigationTargets != null && navigationTargets.Length > 0 ? navigationTargets[0] : null;
        }

        public void Initialize(Station station)
        {
            this.station = station;
            SetupNavigationTargets();
        }

        private void Start()
        {
            HQEvents.OnWorkStationCreated(this);
        }

        public Vector3 GetLocation()
        {
            return GetFirstFreeNavTarget().position;
        }
 
        public bool Interact<T>(T other)
        {
            Debug.Log("interacting");
            Buddy buddy = other as Buddy;
            station.AddBuddyToStation(buddy);
            SubscribeToTicks(TickTime.Large);
            return true; // if the station is full, it won't allow interactions
        }

        public void StopInteraction<T>(T other)
        {
            Debug.Log("stop interacting");
            Buddy buddy = other as Buddy;
            station.RemoveBuddyFromStation(buddy);
            StopNeedHeallingTick(TickTime.Large);
   
        }
        public void SubscribeToTicks(TickTime tickTime)
        {
            TimeEvents.OnRegisterTickListenerRequested?.Invoke(this, tickTime);
        }

        public void StopNeedHeallingTick(TickTime tickTime)
        {
            TimeEvents.OnRemoveTickListenerRequested?.Invoke(this, tickTime);
        }

        private void healNeed(Need need)
        {
            station.healBuddiesNeeds();
        }

        public void OnTicked()
        {
            healNeed(station.getNeed());
        }

        private void OnResourceCollected(ResourceType resourceType)
        {
            ResourceEvents.OnResourceCollected(resourceType, 2);
        }

        public Need getStationTaskType()
        {
            return station.getNeed();
        }
    }
}