using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PP.Plants
{
	[System.Serializable]
    public class Plant
    {
        public string plantName;
        public int growPoints;
        public PlantStatus status;
        public PlantType plantType;

        public Plant(PlantData plantData)
        {
            plantName = plantData.plantName;
            plantType = plantData.plantType;
            status = PlantStatus.Growing;
            growPoints = 0;
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
                Debug.Log(this.status);
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