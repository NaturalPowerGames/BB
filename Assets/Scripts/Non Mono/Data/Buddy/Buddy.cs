using System;
using System.Linq;

namespace BB.Buddies
{
	[System.Serializable]
	public class Buddy
	{
		private float[] needs;
		private float[] ratesPerTick;
		private float[] needUrgencyThresholds, needSatisfyThresholds;
		private bool[] needsReportedAsUrgent;
		private bool hasHabitatAssigned;
		private bool isWorking;

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
		public Action<Need, bool> OnNeedUrgencyChanged;
		public Action<Need> OnNeedFullyRecovered;
		public Action OnRequestNewTask;
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

		public Buddy(BuddyType buddyType, float[] needs, float[] ratesPerTick, float[] needsUrgencyThresholds, float[] needSatisfyThresholds)
		{
			this.buddyType = buddyType;
			this.needs = needs.ToArray();
			this.ratesPerTick = ratesPerTick.ToArray();
			this.needUrgencyThresholds = needsUrgencyThresholds.ToArray();
			this.needsReportedAsUrgent = new bool[needsUrgencyThresholds.Length];
			this.needSatisfyThresholds = needSatisfyThresholds.ToArray();
			this.isWorking = false;
		}

		public void DecreaseNeed(Need need)
		{
			needs[(int)need] -= ratesPerTick[(int)need];
			needs[(int)need] = Math.Clamp(needs[(int)need], 0, 100);
			OnNeedsChanged?.Invoke(needs);
			if (IsNeedUrgent(need) && !needsReportedAsUrgent[(int)need])
			{
				OnNeedUrgencyChanged?.Invoke(need, true);
				needsReportedAsUrgent[(int)need] = true;
			}
		}

		public void HealNeed(Need need, float amount)
		{
			needs[(int)need] += amount;
			needs[(int)need] = Math.Clamp(needs[(int)need], 0, 100); //maybe min and top value aren't these later? todo
			OnNeedsChanged?.Invoke(needs);
			if (!IsNeedUrgent(need))
			{
				OnNeedUrgencyChanged?.Invoke(need, false);
				needsReportedAsUrgent[(int)need] = !IsNeedSatisfied(need);
			}
			if (needs[(int)need] >= 99)
			{
				OnNeedFullyRecovered?.Invoke(need);
			}
		}

		private bool IsNeedUrgent(Need need) => needs[(int)need] < needUrgencyThresholds[(int)need];
		private bool IsNeedSatisfied(Need need) => needs[(int)need] > needSatisfyThresholds[(int)need];
	}
}