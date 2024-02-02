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
            GameObject newPlant = Instantiate(plantPrefabs.prefabs[1], new Vector3(clickedTile.X * GridConstants.tileSize, 0f, clickedTile.Y * GridConstants.tileSize), Quaternion.identity);
            PlantController plantController = newPlant.GetComponent<PlantController>();
            plantController.prefab = newPlant;
            if (plantController == null)
            {
                throw new Exception("New plant cannot be created");
            }
            plantController.plant = new Plant(plantDataContainer.data[1]);
            newPlant.transform.position = Vector3Calculator.CalculatePositionInGrid(clickedTile, newPlant);
            clickedTile.TileStatus = TileStatus.Occupied;
            PlantEvents.OnPlantCreated?.Invoke(plantController);
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
                        plantController.prefab.transform.localScale = new Vector3(0.5f, 2f, 0.5f);
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