using UnityEngine;

namespace BB.Plants
{
	[CreateAssetMenu]
	public class PlantPrefabs : ScriptableObject
	{
		[EnumNamedArray(typeof(PlantType))]
		public PlantController[] prefabs;
	}
}