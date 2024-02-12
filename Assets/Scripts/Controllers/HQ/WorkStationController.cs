using BB.Buddies;
using UnityEngine;
using BB.TimeManagement;
using System.Collections.Generic;

namespace BB.Hub
{
    public class WorkStationController : MonoBehaviour, IInteractable, ITickListener
    {
        public float resourceRate;
        public ResourceType resourceType;
        private List<Buddy> buddiesWorking = new List<Buddy>(), buddiesToRemove = new List<Buddy>();
        [SerializeField]
        private Transform navigationTargetsParent; //this will become an array in the future so that the station can give out many slots and not have them overlap. Also to allow for the station to
        private Transform[] navigationTargets;

        private void Awake()
        {
            SetupNavigationTargets();
        }

        private void OnEnable()
        {
            ResourceEvents.OnStopCollecting += OnStopCollecting;
        }        
        
        private void OnDisable()
        {
            ResourceEvents.OnStopCollecting -= OnStopCollecting;
        }

        private void Start()
        {
            HQEvents.OnWorkStationCreated(this);
            TaskEvents.OnTaskCreated?.Invoke(TaskType.Logging);
        }

        private void SetupNavigationTargets()
        {
            navigationTargets = new Transform[navigationTargetsParent.childCount];
            for (int i = 0; i < navigationTargets.Length; i++)
            {
                navigationTargets[i] = navigationTargetsParent.GetChild(i);
            }
        }

        public Vector3 GetLocation()
        {
            return navigationTargets[0].position;
        }
 
        public bool Interact<T>(T other)
        {
            Buddy buddy = other as Buddy;
            buddiesWorking.Add(buddy);
            SubscribeToTicks(TickTime.Large);
            return true; // if the station is full, it won't allow interactions
        }


        public void StopInteraction<T>(T other)
        {
            Buddy buddy = other as Buddy;
            buddiesToRemove.Add(buddy);
        }
        public void SubscribeToTicks(TickTime tickTime)
        {
            TimeEvents.OnRegisterTickListenerRequested?.Invoke(this, tickTime);
        }

        public void OnStopCollecting(TickTime tickTime)
        {
            Debug.Log("UnsubscribeToTicks");
            TimeEvents.OnRemoveTickListenerRequested?.Invoke(this, tickTime);
        }

        public void OnTicked()
        {
            OnResourceCollected(ResourceType.Wood);
        }

        private void OnResourceCollected(ResourceType resourceType)
        {
            ResourceEvents.OnResourceCollected(resourceType, 2);
        }

    }
}