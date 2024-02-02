using UnityEngine;

namespace BB.SFX
{
	[CreateAssetMenu(menuName = "Custom/Audio")]
	public class SFXData : ScriptableObject
	{
		[EnumNamedArray(typeof(SFX))]
		public AudioClip[] SFXClips;
	}
}