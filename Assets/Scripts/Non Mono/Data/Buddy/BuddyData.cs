using UnityEngine;

namespace BB.Buddies
{
	/// <summary>
	/// Contains the balancing data for each buddy
	/// </summary>
	[System.Serializable]
	public class BuddyData
	{
		public HabitatType PreferredHabitat;
		[EnumNamedArray(typeof(Ability))]
		public int[] BaseAbilityScores;
		[Header("Need Related")]
		[EnumNamedArray(typeof(Need))]
		public float[] RatesPerTick;
		[EnumNamedArray(typeof(Need))]
		public float[] BaseNeeds;
		[EnumNamedArray(typeof(Need))]
		public float[] NeedsUrgencyThresholds;
		[EnumNamedArray(typeof(Need))]
		public float[] NeedsSatisfyThresholds;
	}
}