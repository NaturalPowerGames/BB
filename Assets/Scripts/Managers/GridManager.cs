using System;
using UnityEngine;
using BB.Grid;

public class GridManager : MonoBehaviour
{
	public Tile[,] gridTiles;

	void Start()
	{
		CreateGrid();
	}

	private void OnEnable()
	{
		InputEvents.OnRightMouseButtonDown += OnRightMouseButtonDown;
    }

	private void OnDisable()
	{
		InputEvents.OnRightMouseButtonDown -= OnRightMouseButtonDown;
	}

	private void OnRightMouseButtonDown()
	{
		var tile = GetClickedTile();
		if(tile?.TileStatus == TileStatus.Empty)
		{
			GridEvents.OnPlantRequested?.Invoke(tile);
		}

		if (tile?.TileStatus == TileStatus.Occupied && tile.PlantStatus == PlantStatus.Ready)
		{
            HarvestPlant(tile);
		}
	}

	private void HarvestPlant(Tile tile)
	{
		tile.TileStatus = TileStatus.Empty;
		PlantEvents.OnPlantHarvested?.Invoke(tile.PlantController.plant); // This event do nothing for now, will be used later for removing harvest task in task queue
        GameObject.Destroy(tile.PlantController.gameObject);
    }

    private void CreateGrid()
	{
		gridTiles = new Tile[GridConstants.gridSizeX, GridConstants.gridSizeY];

		for (int x = 0; x < GridConstants.gridSizeX; x++)
		{
			for (int y = 0; y < GridConstants.gridSizeY; y++)
			{
				Tile tile = new Tile(x, y);
				gridTiles[x, y] = tile;
			}
		}
	}

	private Vector2 GetMousePosInGrid()
	{
        int gridLayerMask = LayerMask.GetMask("Grid");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, GridConstants.maxRaycastDistance, gridLayerMask))
		{
			return new Vector2(hit.point.x, hit.point.z);
		}
		throw new InvalidOperationException("No hit point found.");
	}

	public Tile GetClickedTile()
	{
		Vector2 mousePos = GetMousePosInGrid();
		int x = Mathf.FloorToInt(mousePos.x / GridConstants.tileSize);
		int y = Mathf.FloorToInt(mousePos.y / GridConstants.tileSize);

		if(x >= 0 && x < GridConstants.gridSizeX && y >= 0 && y < GridConstants.gridSizeY)
		{
			return gridTiles[x, y];
		}

		return null;
	}

	private void OnDrawGizmos()
	{
		DrawGrid();
	}

	void DrawGrid()
	{
		Gizmos.color = Color.blue;

		for (float x = 0; x <= GridConstants.gridSizeX * GridConstants.tileSize; x += GridConstants.tileSize)
		{
			Gizmos.DrawLine(new Vector3(x, 0, 0), new Vector3(x, 0, GridConstants.gridSizeY * GridConstants.tileSize));
		}

		for (float y = 0; y <= GridConstants.gridSizeY * GridConstants.tileSize; y += GridConstants.tileSize)
		{
			Gizmos.DrawLine(new Vector3(0, 0, y), new Vector3(GridConstants.gridSizeX * GridConstants.tileSize, 0, y));
		}
	}
}