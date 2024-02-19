using System;
using UnityEngine;

public class ResourceInventoryManager : MonoBehaviour
{
    [SerializeField]
    private int[] resources;

    private void OnEnable()
    {
        ResourceEvents.OnResourceCollected += OnResourceCollected;
    }

    private void OnDisable()
    {
        ResourceEvents.OnResourceCollected += OnResourceCollected;
    }

    private void Awake()
    {
        resources = new int[Enum.GetNames(typeof(GatheringType)).Length];
        resources.InitializeArray();
    }

    private void OnResourceCollected(GatheringType resourceType, int amount)
    {
        resources[(int)resourceType] += amount;
        HUDEvents.OnResourceInventoryUpdate?.Invoke(resourceType, resources[(int)resourceType]);
    }
}
