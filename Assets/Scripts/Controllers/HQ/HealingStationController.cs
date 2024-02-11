using BB.Buddies;
using System.Collections.Generic;
using UnityEngine;
using BB.TimeManagement;
using System;

namespace BB.Hub
{
	public class HealingStationController : MonoBehaviour, IInteractable
	{
		public float healRate;
		public Need healedNeed;
		private List<Buddy> buddiesHealing = new List<Buddy>(), buddiesToRemove = new List<Buddy>();
		private TickCounter tickCounter;
		[SerializeField]
		private Transform navigationTargetsParent; //this will become an array in the future so that the station can give out many slots and not have them overlap. Also to allow for the station to
		private Transform[] navigationTargets;
		// have a max number of interactions

		private void Awake()
		{
			tickCounter = new TickCounter(TickTime.Large);
			SetupNavigationTargets();
		}

		private void SetupNavigationTargets()
		{
			navigationTargets = new Transform[navigationTargetsParent.childCount];
			for (int i = 0; i < navigationTargets.Length; i++)
			{
				navigationTargets[i] = navigationTargetsParent.GetChild(i);
			}
		}

		private void OnEnable()
		{
			tickCounter.OnTicked += OnHealTick;
		}

		private void OnDisable()
		{
			tickCounter.OnTicked -= OnHealTick;
		}

		private void OnHealTick()
		{
			foreach (var buddy in buddiesHealing)
			{
				buddy.HealNeed(healedNeed, healRate);
			}
			foreach (var buddy in buddiesToRemove)
			{
				buddiesHealing.Remove(buddy);
			}			
			buddiesToRemove.Clear();
		}

		public Vector3 GetLocation()
		{
			return navigationTargets[0].position; //needs to be dynamic later
		}

		public bool Interact<T>(T other)
		{
			Buddy buddy = other as Buddy;
			buddiesHealing.Add(buddy);
			return true; // if the station is full, it won't allow interactions
		}

		public void StopInteraction<T>(T other)
		{
			Buddy buddy = other as Buddy;
			buddiesToRemove.Add(buddy);
		}

		private void Update()
		{
			tickCounter.Tick(Time.deltaTime);
		}
	}
}