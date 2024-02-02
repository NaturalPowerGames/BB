using UnityEngine;

public static class Vector3Calculator
{
    public static Vector3 CalculatePositionInGrid(Tile clickedTile, GameObject gameObject)
    {
        Vector3 scale = gameObject.transform.localScale;
        float x = clickedTile.X + GridConstants.tileSize - scale.x;
        float y = clickedTile.Y + GridConstants.tileSize - scale.y;
        return new Vector3(x, 0, y);
    }
}
