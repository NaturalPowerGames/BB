using System;

namespace BB.Buddies
{
	[System.Serializable]
	public class Buddy
	{
		private float[] needs;
		public float[] Needs
		{
			get
			{
				return needs;
			}
			set
			{
				needs = value;
				OnNeedsChanged?.Invoke(needs);
			}
		}

		private float[] ratesPerTick;
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

		public Action<float[]> OnNeedsChanged;

		public BuddyType buddyType;

		public float GetNeed(Need need)
		{
			return needs[(int)need];
		}

		public Buddy(float[] needs, float[] ratesPerTick)
		{
			this.Needs = needs;
			this.ratesPerTick = ratesPerTick;
		}

		public void DecreaseNeed(Need need)
		{
			Needs[(int)need] -= ratesPerTick[(int)need];
		}

		public void HealNeed(Need need, float amount)
		{
			Needs[(int)need] += amount;
		}
	}
}