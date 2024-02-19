using BB.Buddies;
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
    private List<StationController> gatheringStations = new List<StationController>(), healingStations = new List<StationController>();

    private void Start()
    {
        SpawnStationsAtLocation(); //only for testing or starting a map
    }

    private void OnEnable()
    {
        StationEvents<Need>.OnStationCreated += OnStationCreated;
        StationEvents<GatheringType>.OnStationCreated += OnStationCreated;
        StationEvents<Need>.OnNearestStationRequested += OnNearestStationRequested;
        StationEvents<GatheringType>.OnNearestStationRequested -= OnNearestStationRequested;

    }

    private void OnDisable()
    {
        StationEvents<Need>.OnStationCreated -= OnStationCreated;
        StationEvents<GatheringType>.OnStationCreated -= OnStationCreated;
        StationEvents<Need>.OnNearestStationRequested -= OnNearestStationRequested;
        StationEvents<GatheringType>.OnNearestStationRequested -= OnNearestStationRequested;
    }

    private void OnStationCreated(StationController stationController)
    {
        if(stationController.Station is GatheringStation)
		{
            gatheringStations.Add(stationController);
        }
        else if(stationController.Station is NeedHealingStation)
		{
            healingStations.Add(stationController);
		}
    }

    private void OnNearestStationRequested<T>(T requestedType, Vector3 position, Action<IInteractable> response)
    {
        response?.Invoke(FindClosestStation(requestedType, position));
    }

	private StationController FindClosestStation<T>(T requestedType, Vector3 position)
	{
		StationController closestStation = null;
		float closestDistance = float.MaxValue;
        var relevantList = requestedType.IsNeedType() ? healingStations : requestedType.IsGatheringType() ? gatheringStations : null;
        if (relevantList == null) return null;

		foreach (var stationController in relevantList)
		{
			Transform stationTransform = null;
			if (requestedType.IsNeedType() && stationController.Station is NeedHealingStation)
			{
				NeedHealingStation healingStation = stationController.Station as NeedHealingStation;
				if (healingStation.GetNeed() == (Need)(object)requestedType)
				{
					stationTransform = stationController.transform;
				}
				else continue;
			}
			else if (requestedType.IsGatheringType() && stationController.Station is GatheringStation)
			{
				GatheringStation gatheringStation = stationController.Station as GatheringStation;
				if (gatheringStation.GatheringType == (GatheringType)(object)requestedType)
				{
					stationTransform = stationController.transform;
				}
				else continue;
			}

			float distance = Vector3.Distance(stationTransform.position, position);
            if (distance < closestDistance)
            {
                closestStation = stationController;
                closestDistance = distance;
            }
		}
		return closestStation;
	}

	private void SpawnStationsAtLocation()
    {
    //    var drinkingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Water], new Vector3(1, 0.5f, 1), Quaternion.identity);
    //    drinkingStationController.Initialize(new Station(stationDatas.data[(int)Need.Water].need, stationDatas.data[(int)Need.Water].needRate));

    //    var eatingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Food], new Vector3(-10,0.5f, -10), Quaternion.identity);
    //    eatingStationController.Initialize(new Station(stationDatas.data[(int)Need.Food].need, stationDatas.data[(int)Need.Food].needRate));

    //    var loggingStationController = Instantiate(stationPrefabs.prefabs[(int)Need.Logging], new Vector3(10, 1, 10), Quaternion.identity);
    //    loggingStationController.Initialize(new Station(stationDatas.data[(int)Need.Logging].need, stationDatas.data[(int)Need.Logging].needRate));
    }
}
