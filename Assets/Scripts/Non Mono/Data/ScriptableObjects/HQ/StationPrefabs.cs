using BB.Buddies;
using UnityEngine;

namespace BB.Stations
{
	[CreateAssetMenu(menuName = "Custom/Station/Prefabs")]
	public class StationPrefabs : ScriptableObject
	{
		[EnumNamedArray(typeof(Need))]
		public NeedHealingStationController[] needHealingStationPrefabs;
		[EnumNamedArray(typeof(GatheringType))]
		public GatheringStationController[] gatheringStationPrefabs;
	}
}