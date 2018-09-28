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

		public float GrowthTime()
		{
			if(growthTime == 200f)
			{
				Debug.Log("Counting time");
				growthTime = 0;
				foreach (Gene gene in totalGenes)
				{
					growthTime += gene.GetGrowthTime();
				}
				Debug.Log(growthTime + " Growth Time");
			}
			return growthTime;
		}
	}

}
