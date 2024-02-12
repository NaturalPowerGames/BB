using System;
using UnityEngine;

namespace BB.TimeManagement
{
	public class TickManager : MonoBehaviour
	{
		private TickCounter[] tickCounters;

		private void Awake()
		{
			SetupTickCounters();
		}

		private void OnEnable()
		{
			TimeEvents.OnRegisterTickListenerRequested += OnTickerRequested;
			TimeEvents.OnRemoveTickListenerRequested += OnRemoveTickerRequested;
	    }

		private void OnDisable()
		{
			TimeEvents.OnRegisterTickListenerRequested -= OnTickerRequested;
			TimeEvents.OnRemoveTickListenerRequested -= OnRemoveTickerRequested;
		}

		private void OnTickerRequested(ITickListener listener, TickTime tickTime)
		{
			tickCounters[(int)tickTime].OnTicked += listener.OnTicked;
		}
		private void OnRemoveTickerRequested(ITickListener listener, TickTime tickTime)
		{
			Debug.Log("removing");
			tickCounters[(int)tickTime].OnTicked -= listener.OnTicked;
		}

		private void SetupTickCounters()
		{
			tickCounters = new TickCounter[4];
			for (int i = 0; i < tickCounters.Length; i++)
			{
				tickCounters[i] = new TickCounter((TickTime)i);
			}
		}

		private void Update()
		{
			for (int i = 0; i < tickCounters.Length; i++)
			{
				tickCounters[i].Tick(Time.deltaTime);
			}
		}
	}
}