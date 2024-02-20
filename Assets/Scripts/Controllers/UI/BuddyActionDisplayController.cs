using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BB.Buddies
{
	public class BuddyActionDisplayController : MonoBehaviour 
	{
		[SerializeField]
		private Image background;
		[SerializeField]
		private Transform needDisplaysParent;
		private Image[] needDisplays; //this could probably be pooled in the future but it's premature optimization right now todo
		private Dictionary<Need, bool> displayedNeeds = new Dictionary<Need, bool>();
		private Canvas canvas;

		private void Awake()
		{
			SetupComponents();
			ToggleVisuals(false);
		}

		private void SetupComponents()
		{
			canvas = GetComponent<Canvas>();
			canvas.worldCamera = Camera.main;
			needDisplays = needDisplaysParent.GetComponentsInChildren<Image>();
		}

		public void Initialize(Buddy buddy)
		{
			buddy.Needs.OnNeedUrgencyChanged += OnNeedUrgencyChanged;
		}

		private void OnNeedUrgencyChanged(Need need, bool urgent)
		{
			needDisplays[(int)need].gameObject.SetActive(urgent);
			if (displayedNeeds.ContainsKey(need))
			{
				displayedNeeds[need] = urgent;
			}
			else
			{
				displayedNeeds.Add(need, urgent);
			}
		}

		private void ToggleVisuals(bool active)
		{
			foreach (var needDisplay in needDisplays)
			{
				needDisplay.gameObject.SetActive(active);
			}
		}
	}
}