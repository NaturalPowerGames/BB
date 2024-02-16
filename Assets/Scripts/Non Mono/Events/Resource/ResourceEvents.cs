using BB.TimeManagement;
using System;

public static class ResourceEvents
{
    public static Action<ResourceType, int> OnResourceCollected;
}