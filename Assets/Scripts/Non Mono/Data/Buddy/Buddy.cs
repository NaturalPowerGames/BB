using System;
using System.Linq;

namespace BB.Buddies
{
	[System.Serializable]
	public class Buddy
	{
		private Needs needs;
		public Needs Needs => needs;
		private Work work;
		public Work Work => work;

		private HabitatType currentHabitat;
		public HabitatType CurrentHabitat
		{
			get => currentHabitat;
			set
			{
				currentHabitat = value; //this needs to improve Comfort if they are in the right habitat
			}
		}

		public BuddyType buddyType;

        public Buddy(BuddyType buddyType, Needs needs, Work work)
        {
            this.buddyType = buddyType;
            this.needs = needs;          
            this.work = work;
        }	
	}
}