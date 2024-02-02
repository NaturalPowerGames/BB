using PP.Plants;
using System;
using UnityEngine;

public class GridInteractions : MonoBehaviour
{
    public GridManager gridManager;

	private void OnEnable()
	{
        GridEvents.OnPlantRequested += OnPlantRequested;
	}

    private void OnDisable()
    {
        GridEvents.OnPlantRequested += OnPlantRequested;
    }

	private void OnPlantRequested(Tile tile)
	{
        PlantSeed(tile);
    }

    private void PlantSeed(Tile clickedTile)
    {
        PlantEvents.OnPlantCreationRequested?.Invoke(clickedTile);      
    }    
}
