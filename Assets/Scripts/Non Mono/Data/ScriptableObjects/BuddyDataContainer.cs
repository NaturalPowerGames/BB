using System.Collections.Generic;
using UnityEngine;

namespace BB.Buddies
{
	[CreateAssetMenu]
	public class BuddyDataContainer : ScriptableObject
	{
		[EnumNamedArray(typeof(BuddyType))]
		public List<BuddyData> data;
	}
}