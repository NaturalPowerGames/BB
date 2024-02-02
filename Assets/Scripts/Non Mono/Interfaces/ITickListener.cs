namespace BB.TimeManagement
{
	public interface ITickListener
	{
		void SubscribeToTicks(TickTime tickTime);
		void OnTicked();
	}
}