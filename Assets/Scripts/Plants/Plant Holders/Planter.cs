using Holo74.Plants.Genes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.Planter
{
	public class Planter : MonoBehaviour
	{
		[SerializeField]
		private Plant[] plants = new Plant[4]; //Only 0 and 1 should be able to accept plants
		[SerializeField]
		private GameObject[] planterBoxes; //0 and 1 are diagonal from each other
		[SerializeField]
		private GameObject plantPrefab;

		public bool PlantPlant(GenePool seedling, int box)
		{
			bool canPlant = false;
			if(plants[box] == null && (box == 1 || box == 0))
			{
				canPlant = true;
				plants[box] = Instantiate(plantPrefab, planterBoxes[box].transform).GetComponent<Plant>();
				foreach (Gene entity in seedling.GetAllGenes())
				{
					plants[box].GetGenes().ModifyGenes(entity);
				}
				plants[box].PlantGrewUp(RandomGrowthSpread);
			}
			return canPlant;
		}

		private void RandomGrowthSpread(Plant thisPlant)
		{
			int randomSuccess = Random.Range(0, 201);
			if (randomSuccess < thisPlant.GetGenes().TotalFrequency())
			{
				if(randomSuccess % 2 == 0)
				{
					AddingPlant(thisPlant, 2);
				}
				else
				{
					AddingPlant(thisPlant, 3);
				}
			}
		}

		private void AddingPlant(Plant parentGenes, int box)
		{
			if(plants[box] == null)
			{
				plants[box] = Instantiate(plantPrefab, planterBoxes[box].transform).GetComponent<Plant>();
			}
			plants[box].GetGenes().ModifyGenes(parentGenes.GetGenes().GetRandomGene(Random.Range(0, 10)));
		}
	}

}
