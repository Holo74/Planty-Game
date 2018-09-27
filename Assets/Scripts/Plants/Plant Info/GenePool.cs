using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.Genes
{
	[Serializable]
	public class GenePool : object
	{
		public int healing, poison, speed;
		public enum GeneNames
		{
			healing,
			poison,
			speed
		}

		public enum GeneDominate
		{
			healing = 0,
			poison = 1,
			speed = 2
		}

		public void AddingGenes(GeneNames whichGene)
		{
			switch (whichGene)
			{
				case GeneNames.healing:
					break;
				case GeneNames.poison:
					break;
				case GeneNames.speed:
					break;
				default:
					break;
			}
		}
	}

}
