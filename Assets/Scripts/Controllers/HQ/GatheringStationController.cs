namespace BB.Stations
{
	public class GatheringStationController : StationController
	{
		private void Start()
		{
			StationEvents<GatheringType>.OnStationCreated?.Invoke(this);
		}
	}
}