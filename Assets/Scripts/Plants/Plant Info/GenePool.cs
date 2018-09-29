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
		private float growthTime = 200f;
		private int totalFrequency = -1;

		public float GrowthTime()
		{
			if(growthTime == 200f)
			{
				growthTime = 0;
				foreach (Gene gene in totalGenes)
				{
					growthTime += gene.GetGrowthTime();
				}
			}
			return growthTime;
		}

		public int TotalFrequency()
		{
			if(totalFrequency == -1)
			{
				totalFrequency = 0;
				foreach (Gene gene in totalGenes)
				{
					totalFrequency += gene.GetFrequency();
				}
			}
			return totalFrequency;
		}

		public List<Gene> GetAllGenes()
		{
			return totalGenes;
		}

		public Gene GetRandomGene(int random)
		{
			if(totalGenes[1] != null)
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

		public void ModifyGenes(Gene Modifier)
		{
			if(totalGenes.Count == 1)
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
			if(totalGenes.Count == 0)
			{
				totalGenes.Add(Modifier);
			}
		}
	}

}
