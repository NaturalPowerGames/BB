using BB.Buddies;
using BB.Hub;
using BB.Stations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    [SerializeField]
    public StationDataContainer stationDatas;    
    [SerializeField]
    public StationPrefabs stationPrefabs;
    [SerializeField]
    private List<StationController> workStations = new List<StationController>();

    private void Start()
    {
        SpawnStationsAtLocation(); //only for testing or starting a map
    }

    private void OnEnable()
    {
        HQEvents.OnWorkStationCreated += OnWorkStationCreated;
        BuddyEvents.OnBuddyNeedsStation += OnBuddyNeedsStation;
    }

    private void OnDisable()
    {
        HQEvents.OnWorkStationCreated -= OnWorkStationCreated;
        BuddyEvents.OnBuddyNeedsStation -= OnBuddyNeedsStation;
    }

    private void OnWorkStationCreated(StationController workStationController)
    {
        workStations.Add(workStationController);
    }

    private void OnBuddyNeedsStation(Need need, Vector3 position, Action<IInteractable> response)
    {
        response?.Invoke(FindClosestStation(need, position));
    }

    private StationController FindClosestStation(Need need, Vector3 position)
    {
        StationController closestStation = null;
        float closestDistance = float.MaxValue;

        foreach (var stationController in workStations)
        {
            if (stationController.getStationTaskType() == need)
            {
                float distance = Vector3.Distance(stationController.transform.position, position);
                if (distance < closestDistance)
                {
                    closestStation = stationController;
                    closestDistance = distance;
                }
            }
        }

        return closestStation;
    }

    private void SpawnStationsAtLocation()
    {
        var logginStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Water], new Vector3(1, 1, 1), Quaternion.identity);
        logginStationController.Initialize(new Station(Need.Water));
        var waterStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Food], new Vector3(5, 1, 5), Quaternion.identity);
        waterStationController.Initialize(new Station(Need.Food));
        var LoggingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Logging], new Vector3(-5, 1, -5), Quaternion.identity);
        LoggingStationController.Initialize(new Station(Need.Logging));
    }
}
