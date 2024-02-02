using UnityEngine;

namespace BB.Buddies
{
	[CreateAssetMenu]
	public class BuddyPrefabs : ScriptableObject
	{
		[EnumNamedArray(typeof(BuddyType))]
		public BuddyController[] prefabs;
	}
}