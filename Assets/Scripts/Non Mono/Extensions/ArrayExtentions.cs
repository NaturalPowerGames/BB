using System;

public static class ArrayExtensions
{
    public static T[] InitializeArray<T>(this T[] array, T value = default(T))
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
        return array;
    }

    public static T[] InitializeArraySequential<T>(this T[] array) where T : struct
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = (T)Convert.ChangeType(i, typeof(T));
        }
        return array;
    }
}