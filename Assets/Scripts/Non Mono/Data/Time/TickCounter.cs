using System;

namespace BB.TimeManagement
{
	public class TickCounter
	{
		private int ticksSinceCreated = 0;
		private float tickTimer, tickCountdown;
		public int TicksSinceCreated => ticksSinceCreated;
		public Action OnTicked;

		public TickCounter(TickTime tickTime)
		{
			tickTimer = Constants.TickTimes[(int)tickTime];
		}

		public void Tick(float deltaTime)
		{
			tickCountdown -= deltaTime;
			if (tickCountdown > tickTimer)
			{
				tickCountdown -= tickTimer;
				ticksSinceCreated++;
				OnTicked?.Invoke();
			}
		}
	}
}