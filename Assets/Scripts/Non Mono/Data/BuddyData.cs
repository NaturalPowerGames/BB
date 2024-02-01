using UnityEngine;

namespace BB.Buddies
{
	/// <summary>
	/// Contains the balancing data for each buddy
	/// </summary>
	public class BuddyData
	{
		public HabitatType preferredHabitat;
		[Header("Make 5!!")]
		public float[] NeedRates;
	}
}