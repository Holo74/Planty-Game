using Holo74.Plants.Genes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.Seed
{
	public class Seeds : MonoBehaviour
	{
		private GenePool genes;

		public GenePool GetPlantGenes()
		{
			return genes;
		}
	}

}
