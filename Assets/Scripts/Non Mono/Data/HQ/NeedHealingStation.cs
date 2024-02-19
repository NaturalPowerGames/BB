using BB.Buddies;

namespace BB.Stations
{
	public class NeedHealingStation : Station
	{
		private readonly Need need;
		public Need GetNeed()
		{
			return need;
		}

		public override void PerformInteractionEffect()
		{
			foreach (var buddy in buddiesInteracting)
			{
				buddy.Needs.HealNeed(need, interactionBenefitRate);
			}
			base.PerformInteractionEffect();
		}

		public NeedHealingStation(Need need, float rate)
		{
			this.need = need;
			this.interactionBenefitRate = rate;
		}
	}
}