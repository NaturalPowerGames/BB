using System;
using UnityEngine;

namespace BB.Buddies
{
	public class BuddyDataUIController : MonoBehaviour
	{
		private Canvas canvas;

		private void Awake()
		{
			SetupCanvas();
		}

		private void SetupCanvas()
		{
			canvas = GetComponent<Canvas>();
			canvas.worldCamera = Camera.main;
		}

		internal void Initialize(Buddy buddy)
		{
			//setup events here
		}
	}
}