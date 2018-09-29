using Holo74.Plants.Genes;
using UnityEngine;

namespace Holo74.Plants.GeneFunctions
{
	[CreateAssetMenu(fileName = "Combine", menuName = "Gene Equation/Combine Genes")]
	public class CombineGenes : ScriptableObject
	{
		[SerializeField]
		private Gene first, second, outcome;

		public (bool, Gene) ReturnGeneAndTrue(Gene _first, Gene _second)
		{
			bool foundGene = false;
			Gene getGene = null;
			if(_first == first)
			{
				if(_second == second)
				{
					foundGene = true;
					getGene = outcome;
				}
			}
			if (_first == second)
			{
				if (_second == first)
				{
					foundGene = true;
					getGene = outcome;
				}
			}
			return (foundGene, getGene);
		} 
	}

}
