using UnityEngine;

public class GridInteractions : MonoBehaviour
{
    public GridManager gridManager;
    public GameObject plantPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Tile clickedTile = gridManager.GetClickedTile();
            if (clickedTile != null && clickedTile.TileStatus == TileStatus.Empty)
            {
                plantSeed(clickedTile);
            }
        }
    }

    void plantSeed(Tile clickedTile)
    {
        GameObject newPlant = Instantiate(plantPrefab, new Vector3(clickedTile.X * GridConstants.tileSize, 0f, clickedTile.Y * GridConstants.tileSize), Quaternion.identity);
        newPlant.transform.position = calculatePositionInGrid(clickedTile, newPlant);

        clickedTile.TileStatus = TileStatus.Occupied;
    }

    Vector3 calculatePositionInGrid(Tile clickedTile, GameObject gameObject)
    {
        Vector3 scale = gameObject.transform.localScale;
        float x = clickedTile.X + GridConstants.tileSize - scale.x;
        float y = clickedTile.Y + GridConstants.tileSize - scale.y;
        return new Vector3(x, 0, y);
    }
}
