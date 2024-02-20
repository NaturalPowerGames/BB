namespace BB.Stations
{
	public class GatheringStation : Station
	{
		private GatheringType gatheringType;
		public GatheringType GatheringType => gatheringType;

		public GatheringStation(GatheringType gatheringType, float interactionBenefitRate)
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