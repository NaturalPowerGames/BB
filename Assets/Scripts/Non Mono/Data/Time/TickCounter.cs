using System;

namespace BB.TimeManagement
{
	public class TickCounter
	{
		private int ticksSinceCreated = 0;
		private float baseTickTime, tickTimer;
		public int TicksSinceCreated => ticksSinceCreated;
		public Action OnTicked;

		public TickCounter(TickTime tickTime)
		{
			baseTickTime = Constants.TickTimes[(int)tickTime];
		}

		public void Tick(float deltaTime)
		{
			tickTimer += deltaTime;
			if (tickTimer > baseTickTime)
			{
				tickTimer -= baseTickTime;
				ticksSinceCreated++;
				OnTicked?.Invoke();
			}
		}
	}
}