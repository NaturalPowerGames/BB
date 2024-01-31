using System;

public static class BuddyEvents 
{
	public static Action<Buddy> OnNeedHealed;
	public static Action<Buddy> OnNeedDecreased;
	public static Action<Buddy> OnNeedEmergency;
	public static Action<Buddy> OnBuddyAged;
	public static Action<Buddy> OnBuddyBorn;

}
