
namespace BB.Buddies
{
	/// <summary>
	/// Contains the balancing data for each buddy
	/// </summary>
	[System.Serializable]
	public class BuddyData
	{
		[EnumNamedArray(typeof(Ability))]
		public int[] BaseAbilityScores;
		[EnumNamedArray(typeof(Need))]
		public float[] RatesPerTick;
		public HabitatType PreferredHabitat;
	}
}