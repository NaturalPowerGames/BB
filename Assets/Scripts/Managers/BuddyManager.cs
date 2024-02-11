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
			buddy.Initialize(new Buddy(buddyType, buddyData.BaseNeeds, buddyData.RatesPerTick, buddyData.NeedsUrgencyThresholds));
		}
	}
}