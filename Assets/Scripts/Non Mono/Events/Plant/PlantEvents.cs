using BB.Plants;
using BB.Grid;
using System;

public static class PlantEvents
{
    public static Action<PlantController> OnPlantCreated;
    public static Action<Tile> OnPlantCreationRequested;
    public static Action<Plant> OnPlantHarvested;
}