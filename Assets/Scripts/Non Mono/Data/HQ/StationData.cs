namespace BB.Stations
{
	[System.Serializable]
	public class StationData
	{
		[EnumNamedArray(typeof(ResourceType))]
		public ResourceType reosurceType;
	}
}