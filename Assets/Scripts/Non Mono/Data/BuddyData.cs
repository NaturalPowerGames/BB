
namespace BB.Buddies
{
	/// <summary>
	/// Contains the balancing data for each buddy
	/// </summary>
	[System.Serializable]
	public class BuddyData
	{
		public HabitatType PreferredHabitat;
		[EnumNamedArray(typeof(Need))]
		public float[] RatesPerTick;
	}
}