using PP.Plants;
using System;
using UnityEngine;

public class GridInteractions : MonoBehaviour
{
    public GridManager gridManager;
    public GameObject plantPrefab;

    public PlantDataContainer plantDataContainer;
    public PlantPrefabs plantPrefabs;

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

    void PlantSeed(Tile clickedTile)
    {
        GameObject newPlant = Instantiate(plantPrefabs.prefabs[1], new Vector3(clickedTile.X * GridConstants.tileSize, 0f, clickedTile.Y * GridConstants.tileSize), Quaternion.identity);
        PlantController plantController = newPlant.GetComponent<PlantController>();
        plantController.prefab = newPlant;
        if (plantController == null)
        {
            throw new Exception("New plant cannot be created");
        }
        plantController.plant = new Plant(plantDataContainer.data[1]);
        newPlant.transform.position = calculatePositionInGrid(clickedTile, newPlant);

        clickedTile.TileStatus = TileStatus.Occupied;
        PlantEvents.OnPlantCreated?.Invoke(plantController);
    }

    Vector3 calculatePositionInGrid(Tile clickedTile, GameObject gameObject)
    {
        Vector3 scale = gameObject.transform.localScale;
        float x = clickedTile.X + GridConstants.tileSize - scale.x;
        float y = clickedTile.Y + GridConstants.tileSize - scale.y;
        return new Vector3(x, 0, y);
    }
}
