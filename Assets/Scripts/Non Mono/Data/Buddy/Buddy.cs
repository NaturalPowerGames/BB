using System;

namespace BB.Buddies
{
	[System.Serializable]
	public class Buddy
	{
		private float[] needs;
		private float[] ratesPerTick;
		private float[] needUrgencyThresholds;
		private bool[] needsReportedAsUrgent;
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
		public Action<Need> OnNeedUrgent;
		public BuddyType buddyType;

		public float GetNeed(Need need)
		{
			return needs[(int)need];
		}

		public void DecreaseAllNeeds()
		{
			for (int i = 0; i < needs.Length; i++)
			{
				DecreaseNeed((Need)i);
			}
		}

		public Buddy(BuddyType buddyType, float[] needs, float[] ratesPerTick, float[] needsUrgencyThresholds)
		{
			this.buddyType = buddyType;
			this.needs = needs;
			this.ratesPerTick = ratesPerTick;
			this.needUrgencyThresholds = needsUrgencyThresholds;
			this.needsReportedAsUrgent = new bool[needsUrgencyThresholds.Length];
		}

		public void DecreaseNeed(Need need)
		{
			needs[(int)need] -= ratesPerTick[(int)need];
			OnNeedsChanged?.Invoke(needs);
			if (IsNeedUrgent(need) && !needsReportedAsUrgent[(int)need])
			{
				OnNeedUrgent?.Invoke(need);
				needsReportedAsUrgent[(int)need] = true;
			}
		}

		public void HealNeed(Need need, float amount)
		{
			needs[(int)need] += amount;
			OnNeedsChanged?.Invoke(needs);
			needsReportedAsUrgent[(int)need] = false;
		}

		private bool IsNeedUrgent(Need need) => needs[(int)need] >= needUrgencyThresholds[(int)need];
	}
}