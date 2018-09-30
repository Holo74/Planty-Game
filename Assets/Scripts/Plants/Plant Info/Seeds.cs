using Holo74.Plants.Genes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.Seed
{
	[Serializable]
	public class Seeds
	{
		private GenePool genes = new GenePool();
		public int amount = 1;

		public Seeds(Gene[] allGenes)
		{
			foreach (Gene entity in allGenes)
			{
				genes.ModifyGenes(entity);
			}
		}

		public GenePool GetPlantGenes()
		{
			return genes;
		}

		public bool SameGenes(GenePool genes)
		{
			bool same = false;
			if(this.genes.GetAllGenes().Count == genes.GetAllGenes().Count)
			{
				same = true;
				for (int i = 0; i < this.genes.GetAllGenes().Count; i++)
				{
					if(this.genes.GetAllGenes()[i] != genes.GetAllGenes()[i])
					{
						same = false;
					}
				}
			}
			return same;
		}
	}

}
