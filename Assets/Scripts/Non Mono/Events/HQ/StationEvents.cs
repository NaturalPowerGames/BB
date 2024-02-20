using System;
using UnityEngine;

namespace BB.Stations
{
	public static class StationEvents<T>
	{
		public static Action<StationController> OnStationCreated;
		public static Action<T, Vector3, Action<IInteractable>> OnNearestStationRequested;
	}
}