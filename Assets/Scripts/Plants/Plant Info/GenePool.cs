using Holo74.Plants.GeneFunctions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.Genes
{
	[Serializable]
	public class GenePool : object
	{
		[SerializeField]
		private List<Gene> totalGenes = new List<Gene>();
		private Gene dominateGene;
		private float growthTime = 200f, waterNeed = 0;
		private int totalFrequency = -1;
		[SerializeField]
		private float minGrowthTime = 10f, minWaterTime = 10f;

		private void CalculateGrowthTime()
		{
			growthTime = 0;
			foreach (Gene gene in totalGenes)
			{
				growthTime += gene.GetGrowthTime();
			}
			growthTime = (growthTime < minGrowthTime) ? minGrowthTime : growthTime;
		}

		private void CalculateTotalFrequency()
		{
			totalFrequency = 0;
			foreach (Gene gene in totalGenes)
			{
				totalFrequency += gene.GetFrequency();
			}
		}

		private void CalculateTotalWaterNeed()
		{
			waterNeed = 0;
			foreach (Gene entity in totalGenes)
			{
				waterNeed += entity.GetWaterPeriod();
			}
			waterNeed = (waterNeed < minWaterTime) ? minWaterTime : waterNeed;
		}

		private void CalculatingDominateGene()
		{
			float geneStrength = 0;
			int selectedGene = 0;
			if(totalGenes.Count > 1)
			{
				for (int i = 0; i < totalGenes.Count; i++)
				{
					if(totalGenes[i].GetPriority() > geneStrength)
					{
						geneStrength = totalGenes[i].GetPriority();
						selectedGene = i;
					}
				}
			}
			dominateGene = totalGenes[selectedGene];
		}

		public float GrowthTime()
		{
			return growthTime;
		}

		public int TotalFrequency()
		{
			return totalFrequency;
		}

		public float GetWaterNeed()
		{
			return waterNeed;
		}

		public List<Gene> GetAllGenes()
		{
			return totalGenes;
		}

		public Gene GetDominateGene()
		{
			return dominateGene;
		}

		public Gene GetRandomGene(int random)
		{
			if(totalGenes.Count > 1)
			{
				if(random % 2 == 0)
				{
					return totalGenes[0];
				}
				else
				{
					return totalGenes[1];
				}
			}
			else
			{
				return totalGenes[0];
			}
		}

		public void ModifyGenes(Gene Modifier, Plant.StageOfGrowth growth)
		{
			if(growth == Plant.StageOfGrowth.seedling)
			{
				if (totalGenes.Count == 1)
				{
					bool canCombine = false;
					Gene possibleCombination = null;
					(canCombine, possibleCombination) = GeneFunctionManager.FindCombineGenes(totalGenes[0], Modifier);
					if (canCombine)
					{
						totalGenes[0] = possibleCombination;
					}
					else
					{
						totalGenes.Add(Modifier);
					}
				}
				if (totalGenes.Count == 0)
				{
					totalGenes.Add(Modifier);
				}
				CalculateGrowthTime();
				CalculateTotalFrequency();
				CalculateTotalWaterNeed();
				CalculatingDominateGene();
			}
		}
	}

}
