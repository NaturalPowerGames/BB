using BB.Plants;

namespace BB.Grid
{    
    public class Tile
    {
        private int x;
        private int y;
        private TileStatus tileStatus;
        private PlantController plantController;


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
        public PlantController PlantController
        {
            get { return plantController; }
            set { plantController = value; }
        }        
        public PlantStatus PlantStatus
        {
            get { return plantController.plant.status; }
            set { plantController.plant.status = value; }
        }
    }

}
