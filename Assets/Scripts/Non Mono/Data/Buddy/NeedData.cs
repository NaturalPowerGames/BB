namespace BB.Buddies
{
	[System.Serializable]
	public class NeedData
	{	
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