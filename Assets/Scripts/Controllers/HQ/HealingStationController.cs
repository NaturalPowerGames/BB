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
		private List<Buddy> buddiesHealing = new List<Buddy>();
		private TickCounter tickCounter;

		private void Awake()
		{
			tickCounter = new TickCounter(TickTime.Large);
			tickCounter.OnTicked += OnHealTick;
		}

		private void OnHealTick()
		{
			foreach (var buddy in buddiesHealing)
			{
				buddy.HealNeed(healedNeed, healRate);
			}
		}

		public Vector3 GetLocation()
		{
			return transform.position; //will be a specified transform location, not the object's, in the future
		}

		public void Interact<T>(T other)
		{
			Buddy buddy = other as Buddy;
			buddiesHealing.Add(buddy);
		}

		public void StopInteraction<T>(T other)
		{
			Buddy buddy = other as Buddy;
			buddiesHealing.Remove(buddy);
		}

		private void Update()
		{
			tickCounter.Tick(Time.deltaTime);
		}
	}
}