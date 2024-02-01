using System.Diagnostics;

public class Tile
{
    private int x;
    private int y;
    private TileStatus tileStatus;


    public Tile(int x, int y, TileStatus tileStatus = TileStatus.Empty)
    {
        this.x = x;
        this.y = y;
        this.tileStatus = tileStatus;
    }
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public TileStatus TileStatus
    {
        get { return tileStatus; }
        set { tileStatus = value; }
    }
}
