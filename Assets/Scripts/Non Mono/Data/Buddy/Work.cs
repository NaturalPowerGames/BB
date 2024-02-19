using System;
using System.Linq;

namespace BB.Buddies
{
	public class Work
	{
		private bool isWorking;
		public bool IsWorking => isWorking;
		private float currentMotivation;
		private bool isMotivated;

		public float CurrentMotivation
		{
			get
			{
				return currentMotivation;
			}
			set
			{
				currentMotivation = value;
				OnMotivationChanged?.Invoke(currentMotivation);
				isMotivated = IsMotivated;

				if (IsMotivated && !isWorking)
				{
					OnRequestNewTask?.Invoke(WeighedRandomTaskSelection());
				}
				else if (!IsMotivated && isWorking)
				{
					OnStopWorkingRequested?.Invoke();
				}
			}
		}

		private GatheringType WeighedRandomTaskSelection()
		{
			float totalWeight = workPreferences.Sum();
			float randomValue = UnityEngine.Random.Range(0f, totalWeight);
			int selectedIndex = workPreferences.Select((w, i) => new { Weight = w, Index = i })
									   .First(x => (randomValue -= x.Weight) <= 0)
									   .Index;
			return (GatheringType)selectedIndex;
		}

		private readonly float motivationDepletionRate, motivationIncreaseRate, minimumMotivationRequiredToWork; //whenever we need to buff/debuff these, we need publics
		private readonly float[] workPreferences;

		public Action<GatheringType> OnRequestNewTask;
		public Action OnStopWorkingRequested;

		public Action<float> OnMotivationChanged;

		public Work(float currentMotivation, float motivationDepletionRate, float motivationIncreaseRate, float minimumMotivationRequiredToWork, float[] workPreferences)
		{
			this.currentMotivation = currentMotivation;
			this.motivationDepletionRate = motivationDepletionRate;
			this.motivationIncreaseRate = motivationIncreaseRate;
			this.minimumMotivationRequiredToWork = minimumMotivationRequiredToWork;
			this.workPreferences = workPreferences;
		}

		public void HealMotivation(float amount)
		{
			CurrentMotivation += amount;
		}

		public void NotWorkingMotivationBaseHeal()
		{
			CurrentMotivation += motivationIncreaseRate;
		}

		public void PerformWork()
		{
			CurrentMotivation -= motivationDepletionRate;
		}

		public bool IsMotivated { get { return currentMotivation >= minimumMotivationRequiredToWork; } }
	}
}