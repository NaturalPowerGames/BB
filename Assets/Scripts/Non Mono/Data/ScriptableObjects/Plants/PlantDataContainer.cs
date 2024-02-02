using System.Collections.Generic;
using UnityEngine;

namespace PP.Plants
{
	[CreateAssetMenu]
	public class PlantDataContainer : ScriptableObject
	{
		[EnumNamedArray(typeof(PlantType))]
		public List<PlantData> data;
	}
}