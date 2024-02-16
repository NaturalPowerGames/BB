using BB.Hub;
using System;
using UnityEngine;

namespace BB.Buddies
{
	public static class BuddyEvents
	{
		public static Action<Buddy> OnNeedHealed;
		public static Action<Buddy> OnNeedDecreased;
		public static Action<Buddy> OnNeedEmergency;
		public static Action<Buddy> OnBuddyAged;
		public static Action<Buddy> OnBuddyBorn;
		public static Action<Buddy> OnBuddySelected;
		public static Action<Need, Vector3, Action<IInteractable>> OnBuddyNeedsStation;
	}
}