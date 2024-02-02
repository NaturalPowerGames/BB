using System;

namespace BB.TimeManagement
{
	public static class TimeEvents
	{
		public static Action<ITickListener, TickTime> OnRegisterTickListenerRequested;
	}
}