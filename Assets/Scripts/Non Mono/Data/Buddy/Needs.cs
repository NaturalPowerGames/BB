using System;

namespace BB.Buddies
{
	[System.Serializable]
	public class Needs
	{
		private float[] currentNeeds;
		private float[] ratesPerTick;
		private float[] needUrgencyThresholds, needSatisfyThresholds;
		private bool[] needsReportedAsUrgent;
		public Action<float[]> OnNeedsChanged;
		public Action<Need, bool> OnNeedUrgencyChanged;
		public Action<Need> OnNeedFullyRecovered;

		public Needs(float[] needs, float[] ratesPerTick, float[] needUrgencyThresholds, float[] needSatisfyThresholds)
		{
			this.currentNeeds = needs ?? new float[5];
			this.ratesPerTick = ratesPerTick;
			this.needUrgencyThresholds = needUrgencyThresholds;
			this.needSatisfyThresholds = needSatisfyThresholds;
			this.needsReportedAsUrgent = new bool[5];		
		}

		public float GetNeed(Need need)
		{
			return currentNeeds[(int)need];
		}

		public void DecreaseAllNeeds()
		{
			for (int i = 0; i < currentNeeds.Length; i++)
			{
				DecreaseNeed((Need)i);
			}
		}

		public void DecreaseNeed(Need need)
		{
			currentNeeds[(int)need] -= ratesPerTick[(int)need];
			currentNeeds[(int)need] = Math.Clamp(currentNeeds[(int)need], 0, 100);
			OnNeedsChanged?.Invoke(currentNeeds);
			if (IsNeedUrgent(need) && !needsReportedAsUrgent[(int)need])
			{
				OnNeedUrgencyChanged?.Invoke(need, true);
				needsReportedAsUrgent[(int)need] = true;
			}
		}

		public void HealNeed(Need need, float amount)
		{
			currentNeeds[(int)need] += amount;
			currentNeeds[(int)need] = Math.Clamp(currentNeeds[(int)need], 0, 100); //maybe min and top value aren't these later? todo
			OnNeedsChanged?.Invoke(currentNeeds);

			if (!IsNeedUrgent(need))
			{
				OnNeedUrgencyChanged?.Invoke(need, false);
				needsReportedAsUrgent[(int)need] = !IsNeedSatisfied(need);
			}

			if (currentNeeds[(int)need] >= 99)
			{
				OnNeedFullyRecovered?.Invoke(need);
			}
		}

		private bool IsNeedUrgent(Need need) => currentNeeds[(int)need] < needUrgencyThresholds[(int)need];
		private bool IsNeedSatisfied(Need need) => currentNeeds[(int)need] > needSatisfyThresholds[(int)need];
	}
}