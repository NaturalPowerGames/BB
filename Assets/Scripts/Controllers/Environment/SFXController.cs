using System;
using UnityEngine;

namespace BB.SFX
{
	public class SFXController : MonoBehaviour
	{
		private AudioSource audioSource;
		[SerializeField]
		private SFXData data;

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
		}

		private void OnEnable()
		{
			SFXEvents.OnSFXPlayRequested += OnSFXPlayRequested;
		}

		private void OnDisable()
		{
			SFXEvents.OnSFXPlayRequested -= OnSFXPlayRequested;
		}

		private void OnSFXPlayRequested(SFX sfx)
		{
			audioSource.PlayOneShot(data.SFXClips[(int)sfx]);
		}
	}
}