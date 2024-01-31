using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSizeX = 5;
    public int gridSizeY = 5;
    public float tileSize = 1.0f;

    public Tile[,] gridTiles;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        gridTiles = new Tile[gridSizeX, gridSizeY];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Tile tile = new Tile(x, y);
                gridTiles[x, y] = tile;
            }
        }
    }

    private void OnDrawGizmos()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        Gizmos.color = Color.blue;

        for (float x = 0; x <= gridSizeX * tileSize; x += tileSize)
        {
            Gizmos.DrawLine(new Vector3(x, 0, 0), new Vector3(x, 0, gridSizeY * tileSize));
        }

        for (float y = 0; y <= gridSizeY * tileSize; y += tileSize)
        {
            Gizmos.DrawLine(new Vector3(0, 0, y), new Vector3(gridSizeX * tileSize, 0, y));
        }
    }
}