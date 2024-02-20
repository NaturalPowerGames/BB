using BB.Buddies;

namespace BB.Stations
{
	public class NeedHealingStationController : StationController
	{
		private void Start()
		{
			StationEvents<Need>.OnStationCreated?.Invoke(this);
		}
	}
}