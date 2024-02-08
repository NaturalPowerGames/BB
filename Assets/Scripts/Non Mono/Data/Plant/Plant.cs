using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BB.Plants
{
	[System.Serializable]
    public class Plant
    {
        private string plantName;
        private int growPoints;
        public PlantStatus status;
        public PlantType plantType;
        public ResourceType resourceType;

        public Plant(PlantData plantData)
        {
            plantName = plantData.plantName;
            plantType = plantData.plantType;
            status = PlantStatus.Growing;
            growPoints = 0;
            resourceType = ResourceType.Wood;
        }

        public int GrowPoints
        {
            get { return growPoints; }
        }
        public string PlantName
        {
            get { return plantName; }
        }

        public bool IsPlantReady(int growPoints)
        {
            if (this.status == PlantStatus.Growing && this.growPoints > 30) 
            {
                UpdatePlantStage();
                return true; 
            }

            this.growPoints += growPoints;
            return false;
        }

        void UpdatePlantStage()
        {
            this.status = PlantStatus.Ready;
        }
    }


}