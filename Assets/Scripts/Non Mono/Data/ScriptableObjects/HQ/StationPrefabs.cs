using BB.Buddies;
using UnityEngine;

namespace BB.Stations
{
	[CreateAssetMenu(menuName = "Custom/Station/prefabs")]
	public class StationPrefabs : ScriptableObject
	{
		[EnumNamedArray(typeof(Need))]
		public StationController[] prefabs;
	}
}