namespace BB.Buddies
{
	[System.Serializable]
	public class Buddy
	{
		private float[] needs;
		private bool hasHabitatAssigned;
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

		public float GetNeed(Need need)
		{
			return needs[(int)need];
		}

		public void Initialize(Buddy buddy)
		{
			needs = buddy.needs;
			buddyType = buddy.buddyType;
		}

		public Buddy(float[] needs)
		{
			this.needs = needs;
		}

		public void DecreaseNeeds(float tickTime)
		{
			for (int i = 0; i < needs.Length; i++)
			{
				needs[i] -= tickTime;
			}
		}

		public void HealNeed(Need need, float amount)
		{
			needs[(int)need] += amount;
		}
	}
}