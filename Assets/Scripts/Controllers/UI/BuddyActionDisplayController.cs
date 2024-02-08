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
		
		private void Awake()
		{
			needDisplays = needDisplaysParent.GetComponentsInChildren<Image>();
		}

		public void Initialize(Buddy buddy)
		{
			buddy.OnNeedUrgencyChanged += OnNeedUrgencyChanged;
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

		private void Update()
		{
			needDisplaysParent.position = Camera.main.WorldToScreenPoint(transform.root.position);
		}
	}
}