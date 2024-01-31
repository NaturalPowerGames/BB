using UnityEngine;

public class GridInteractions : MonoBehaviour
{
    public GridManager gridManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tile clickedTile = GetClickedTile(hit.point);

                if (clickedTile != null)
                {
                    Debug.Log("Clicked on Grid Tile: (" + clickedTile.x + ", " + clickedTile.y + ")");
                }
            }
        }
    }

    Tile GetClickedTile(Vector3 clickPosition)
    {
        int x = Mathf.FloorToInt(clickPosition.x / gridManager.tileSize);
        int y = Mathf.FloorToInt(clickPosition.z / gridManager.tileSize);

        if (x >= 0 && x < gridManager.gridSizeX && y >= 0 && y < gridManager.gridSizeY)
        {
            return gridManager.gridTiles[x, y];
        }

        return null; 
    }
}
