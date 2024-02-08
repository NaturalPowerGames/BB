using UnityEngine;

namespace BB.Buddies
{
	[CreateAssetMenu]
	public class NeedSpriteData : ScriptableObject
	{
		[EnumNamedArray(typeof(Need))]
		public Sprite[] sprites;

		public Sprite GetSprite(Need need)
		{
			return sprites[(int)need];
		}
	}
}