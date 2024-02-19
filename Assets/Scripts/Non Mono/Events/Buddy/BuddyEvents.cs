using System;

namespace BB.Buddies
{
	public static class BuddyEvents<T>
	{
		public static Action<Buddy> OnNeedHealed;
		public static Action<Buddy> OnNeedDecreased;
		public static Action<Buddy> OnNeedEmergency;
		public static Action<Buddy> OnBuddyAged;
		public static Action<Buddy> OnBuddyBorn;
		public static Action<Buddy> OnBuddySelected;
	}
}