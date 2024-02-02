using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PP.Plants
{
    public class PlantManager : MonoBehaviour
    {
        public List<PlantController> growingPlants = new List<PlantController>();
        public List<PlantController> readyPlants = new List<PlantController>();

        private void OnEnable()
        {
            PlantEvents.OnPlantCreated += OnPlantCreated;
        }

        private void OnDisable()
        {
            PlantEvents.OnPlantCreated -= OnPlantCreated;
        }
        private void Start()
        {
            StartCoroutine(UpdateGrowPoints());
        }
        IEnumerator UpdateGrowPoints()
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
        void OnPlantCreated(PlantController plant)
        {
            growingPlants.Add(plant);
        }
    }
}