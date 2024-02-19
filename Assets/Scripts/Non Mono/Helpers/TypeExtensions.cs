using System;
using BB.Buddies;

public static class TypeExtensions
{
    public static bool IsNeedType<T>(this T type) 
    {
        return typeof(T) == typeof(Need);
    }

    public static bool IsGatheringType<T>(this T type)
    {
        return typeof(T) == typeof(GatheringType);
    }
}