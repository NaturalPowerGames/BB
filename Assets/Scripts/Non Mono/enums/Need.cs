using System.Collections.Generic;

namespace BB.Buddies
{
	public enum Need
	{
		Food,
		Water,
		Sleep,
		Social,
		Comfort,
		Logging,
		Mining,
	}

    public enum Resource
    {
        Wood,
        Stone,
    }

    public static class NeedExtensions
    {
        private static readonly Dictionary<Need, Resource> resourceMappings = new Dictionary<Need, Resource>
        {
            { Need.Logging, Resource.Wood },
            { Need.Mining, Resource.Stone },
        };

        public static bool ProducesResource(this Need need)
        {
            return resourceMappings.ContainsKey(need);
        }

        public static Resource GetProducedResource(this Need need)
        {
            return resourceMappings[need];
        }
    }
}