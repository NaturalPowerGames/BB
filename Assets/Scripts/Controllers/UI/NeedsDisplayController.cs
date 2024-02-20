using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BB.Buddies;
using UnityEngine.UI;

namespace BB.UI
{
	public class NeedsDisplayController : MonoBehaviour
	{
		[SerializeField]
		[EnumNamedArray(typeof(Need))]
		private TextMeshProUGUI[] needTexts;
		[SerializeField]
		private Button closeButton;
		[SerializeField]
		private GameObject background;

		private void Awake()
		{
			SetupButtons();
			ToggleVisuals(false);
		}

		private void OnEnable()
		{
			BuddyEvents<Need>.OnBuddySelected += OnBuddySelected; //this isn't foolproof, very POC
		}

		private void OnDisable()
		{
			BuddyEvents<Need>.OnBuddySelected -= OnBuddySelected;
		}

		private void OnBuddySelected(Buddy buddy)
		{
			ToggleVisuals(true);
			buddy.Needs.OnNeedsChanged += OnNeedsChanged;
		}

		private void OnNeedsChanged(float[] needs)
		{
			for (int i = 0; i < needs.Length; i++)
			{
				needTexts[i].text = $"{(Need)i}: {needs[i]}/100";
			}
		}

		private void SetupButtons()
		{
			closeButton.onClick.AddListener(() =>
			{
				ToggleVisuals(false);
			});
		}

		private void ToggleVisuals(bool active)
		{
			background.SetActive(active);
		}
	}
}