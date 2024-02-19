namespace BB.Stations
{
	public class WorkStation : Station
	{
		private GatheringType gatheringType;
		
		public WorkStation(GatheringType gatheringType, float interactionBenefitRate)
		{
			this.gatheringType = gatheringType;			
			this.interactionBenefitRate = interactionBenefitRate;
		}

		public override void PerformInteractionEffect()
		{
			foreach (var buddy in buddiesInteracting)
			{
				ResourceEvents.OnResourceCollected?.Invoke(gatheringType, interactionBenefitRate);
			}
			base.PerformInteractionEffect();
		}
	}
}