using System;
using UnityEngine;

public class ResourceInventoryManager : MonoBehaviour
{
    [SerializeField]
    private float[] resources;

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
        resources = new float[Enum.GetNames(typeof(GatheringType)).Length];
        resources.InitializeArray();
    }

    private void OnResourceCollected(GatheringType resourceType, float amount)
    {
        resources[(int)resourceType] += amount;
        HUDEvents.OnResourceInventoryUpdate?.Invoke(resourceType, resources[(int)resourceType]);
    }
}
