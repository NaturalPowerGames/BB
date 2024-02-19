using BB.Buddies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BB.Stations
{
	public class HealingStation : Station
	{
		private Need need;
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
	}
}