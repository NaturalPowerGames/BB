using BB.Buddies;
using System;
using System.Linq;
using UnityEngine;

namespace BB.Hub
{
	public class HealingStationManager : MonoBehaviour
	{
		[SerializeField]
		[EnumNamedArray(typeof(Need))]
		private HealingStationController[] healingStations;

		private void OnEnable()
		{
			BuddyEvents.OnClosestHealingStationRequested += OnClosestHealingStationRequested;
		}

		private void OnClosestHealingStationRequested(Need need, Vector3 position, Action<IInteractable> response)
		{
			response?.Invoke(FindClosestHealingStation(need, position));
		}

		//This should be used in the future for many healing stations for each need, so the healing stations array is very 
		//temporary
		private HealingStationController FindClosestHealingStation(Need need, Vector3 position)
		{
			var closestStation = healingStations
			.OrderBy(station => Vector3.Distance(station.transform.position, position))
			.FirstOrDefault();
			return closestStation;
		}
	}
}