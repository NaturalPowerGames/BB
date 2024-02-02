using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PP.Plants
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
        }

		private void OnPlantCreationRequested(Tile clickedTile)
		{
            PlantController newPlant = Instantiate(plantPrefabs.prefabs[1], new Vector3(clickedTile.X * GridConstants.tileSize, 0f, clickedTile.Y * GridConstants.tileSize), Quaternion.identity);
            newPlant.plant = new Plant(plantDataContainer.data[1]);
            newPlant.transform.position = Vector3Calculator.CalculatePositionInGrid(clickedTile, newPlant.transform);
            clickedTile.TileStatus = TileStatus.Occupied;
            PlantEvents.OnPlantCreated?.Invoke(newPlant);
        }

		private void OnDisable()
        {
            PlantEvents.OnPlantCreated -= OnPlantCreated;
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