using PP.Plants;
using System;

public static class PlantEvents
{
    public static Action<PlantController> OnPlantCreated;
    public static Action<Tile> OnPlantCreationRequested;
}