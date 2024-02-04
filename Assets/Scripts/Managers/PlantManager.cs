using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BB.Grid;

namespace BB.Plants
{
    public class PlantManager : MonoBehaviour
    {
        [SerializeField]
        private List<PlantController> growingPlants = new List<PlantController>();
        [SerializeField]
        private List<PlantController> readyPlants = new List<PlantController>();
        [SerializeField]
        private PlantPrefabs plantPrefabs;
        [SerializeField]
        private PlantDataContainer plantDataContainer;

        private void OnEnable()
        {
            PlantEvents.OnPlantCreationRequested += OnPlantCreationRequested;
            PlantEvents.OnPlantCreated += OnPlantCreated;
            PlantEvents.OnPlantHarvested += OnPlantHarvested;
        }
        private void OnDisable()
        {
            PlantEvents.OnPlantCreationRequested -= OnPlantCreationRequested;
            PlantEvents.OnPlantHarvested -= OnPlantHarvested;
        }

        private void OnPlantHarvested(Plant plant)
        {
            Debug.Log("harvest: " + plant.PlantName);
        }

        private void OnPlantCreationRequested(Tile clickedTile)
		{
            PlantController newPlantController = Instantiate(plantPrefabs.prefabs[1], new Vector3(clickedTile.X * GridConstants.tileSize, 0f, clickedTile.Y * GridConstants.tileSize), Quaternion.identity);
            newPlantController.plant = new Plant(plantDataContainer.data[1]);
            newPlantController.transform.position = Vector3Calculator.CalculatePositionInGrid(clickedTile, newPlantController.transform);
            clickedTile.TileStatus = TileStatus.Occupied;
            clickedTile.PlantController = newPlantController;
            PlantEvents.OnPlantCreated?.Invoke(newPlantController);
        }

        private void Start()
        {
            StartCoroutine(UpdateGrowPoints());
        }

        private IEnumerator UpdateGrowPoints()
        {
            while (true)
            {
                yield return new WaitForSeconds(PlantConstants.tickRate);
                for (int i = growingPlants.Count - 1; i >= 0; i--)
                {
                    PlantController plantController = growingPlants[i];

                    if (plantController.plant.IsPlantReady(PlantConstants.growTicksAmount))
                    {
                        growingPlants.RemoveAt(i);
                        readyPlants.Add(plantController);
                        plantController.transform.localScale = new Vector3(0.5f, 2f, 0.5f);
                        continue;
                    }
                }
            }
        }

        private void OnPlantCreated(PlantController plant)
        {
            growingPlants.Add(plant);
        }
    }
}