using BB.Buddies;
using BB.Hub;
using BB.TimeManagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public List<Task> tasks = new List<Task>();
    [SerializeField]
    public List<WorkStationController> workStations = new List<WorkStationController>();

    private void OnEnable()
    {
        TaskEvents.OnTaskCreated+= OnTaskCreated;
        HQEvents.OnWorkStationCreated += OnWorkStationCreated;
        BuddyEvents.OnBuddyWantsToWork += OnBuddyWantsToWork;
    }

    private void OnDisable()
    {
        TaskEvents.OnTaskCreated -= OnTaskCreated;
        HQEvents.OnWorkStationCreated -= OnWorkStationCreated;
        BuddyEvents.OnBuddyWantsToWork -= OnBuddyWantsToWork;
    }

    private void OnWorkStationCreated(WorkStationController workStationController)
    {
        workStations.Add(workStationController);
    }

    private void OnTaskCreated(TaskType tasktype)
    {
        Task newTask = new Task(tasktype);
        tasks.Add(newTask);
    }

    private void OnBuddyWantsToWork(ResourceType resourceType, Vector3 position, Action<IInteractable> response)
    {
        response?.Invoke(FindClosestTaskStation(resourceType, position));
    }

    private WorkStationController FindClosestTaskStation(ResourceType resourceType, Vector3 position)
    {
        var closestStation = workStations;
        return closestStation[0];
    }
}
