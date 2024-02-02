using UnityEngine;

namespace BB.SFX
{
	public class SFXData : ScriptableObject
	{
		[EnumNamedArray(typeof(SFX))]
		public AudioClip[] SFXClips;
	}
}