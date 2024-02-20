using UnityEngine;

namespace BB.Buddies
{
	public class BuddyManager : MonoBehaviour
	{
		[SerializeField]
		private BuddyDataContainer dataContainer;
		[SerializeField]
		private BuddyPrefabs buddyPrefabs;
		[SerializeField]
		private Transform testBuddySpawnLocation; //remove after testing;
       

        private void Start()
		{
			SpawnBuddyAtLocation(BuddyType.WolfPup, testBuddySpawnLocation.position);		
		}

		private void SpawnBuddyAtLocation(BuddyType buddyType, Vector3 position)
		{
			var buddy = Instantiate(buddyPrefabs.prefabs[(int)buddyType], position, Quaternion.identity);
			var buddyData = dataContainer.data[(int)buddyType];
			var needs = new Needs(buddyData.NeedData.BaseNeeds, buddyData.NeedData.RatesPerTick, buddyData.NeedData.NeedsUrgencyThresholds, buddyData.NeedData.NeedsSatisfyThresholds);
			var work = new Work(buddyData.WorkData.BaseMotivation, buddyData.WorkData.MotivationDepletionRate, buddyData.WorkData.MotivationIncreaseRate, buddyData.WorkData.MinimumMotivationRequiredToWork, buddyData.WorkData.WorkPreferences);
			buddy.Initialize(new Buddy(buddyType, needs, work));
		}
	}
}