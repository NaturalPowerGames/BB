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
        BuddyEvents.OnNearestStationRequested += OnBuddyNeedsStation;
    }

    private void OnDisable()
    {
        HQEvents.OnWorkStationCreated -= OnWorkStationCreated;
        BuddyEvents.OnNearestStationRequested -= OnBuddyNeedsStation;
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
            if (stationController.GetStationTaskType() == need)
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
        var drinkingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Water], new Vector3(1, 0.5f, 1), Quaternion.identity);
        drinkingStationController.Initialize(new Station(stationDatas.data[(int)Need.Water].need, stationDatas.data[(int)Need.Water].needRate));

        var eatingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Food], new Vector3(-10,0.5f, -10), Quaternion.identity);
        eatingStationController.Initialize(new Station(stationDatas.data[(int)Need.Food].need, stationDatas.data[(int)Need.Food].needRate));

        var loggingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Logging], new Vector3(10, 1, 10), Quaternion.identity);
        loggingStationController.Initialize(new Station(stationDatas.data[(int)Need.Logging].need, stationDatas.data[(int)Need.Logging].needRate));
    }
}
