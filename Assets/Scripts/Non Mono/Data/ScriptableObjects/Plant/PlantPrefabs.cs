using UnityEngine;

namespace PP.Plants
{
	[CreateAssetMenu]
	public class PlantPrefabs : ScriptableObject
	{
		[EnumNamedArray(typeof(PlantType))]
		public PlantController[] prefabs;
	}
}