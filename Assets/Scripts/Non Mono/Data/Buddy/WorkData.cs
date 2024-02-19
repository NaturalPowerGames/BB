namespace BB.Buddies
{
	[System.Serializable]
	public class WorkData
	{
		public float BaseMotivation, MotivationDepletionRate, MotivationIncreaseRate, MinimumMotivationRequiredToWork;
		[EnumNamedArray(typeof(GatheringType))]
		public float[] WorkPreferences;
	}
}