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

        public Transform GetFirstFreeNavigationTarget()
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
            HQEvents.OnWorkStationCreated?.Invoke(this);
        }

        public Vector3 GetLocation()
        {
            return GetFirstFreeNavigationTarget().position;
        }
 
        public bool Interact<T>(T other)
        {
            Buddy buddy = other as Buddy;
            Debug.Log($"{buddy.buddyType}: Interacting");
            station.AddBuddyToStation(buddy);
            SubscribeToTicks(TickTime.Large); //when there's more than 1 buddy in ANY station, this needs to go out
            return true; // if the station is full, it won't allow interactions
        }

        public void StopInteraction<T>(T other)
        {
            Buddy buddy = other as Buddy;
            Debug.Log($"{buddy.buddyType}: Stop interacting");
            station.RemoveBuddyFromStation(buddy);
            StopNeedHealingTick(TickTime.Large);   //needs to check if the station is actually empty
        }

        public void SubscribeToTicks(TickTime tickTime)
        {
            TimeEvents.OnRegisterTickListenerRequested?.Invoke(this, tickTime);
        }

        public void StopNeedHealingTick(TickTime tickTime)
        {
            TimeEvents.OnRemoveTickListenerRequested?.Invoke(this, tickTime);
        }

        public void OnTicked()
        {
            station.PerformInteractionEffect();
        }

        private void OnResourceCollected(GatheringType resourceType)
        {
        }
    }
}