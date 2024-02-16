using System.Collections.Generic;
using UnityEngine;
using BB.Buddies;

namespace BB.Stations
{
	[CreateAssetMenu(menuName = "Custom/Station/data")]
	public class StationDataContainer : ScriptableObject
	{
		[EnumNamedArray(typeof(Need))]
		public List<StationData> data;
    }
}