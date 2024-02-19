namespace BB.Buddies
{
	[System.Serializable]
	public class WorkData
	{
		public float BaseMotivation, MotivationDepletionRate, MotivationIncreaseRate, MinimumMotivationRequiredToWork;
		public float[] WorkPreferences;
	}
}