using Holo74.Plants.Genes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.GeneFunctions
{
	public class GeneFunctionManager : MonoBehaviour
	{
		[SerializeField]
		private List<CombineGenes> combinations = new List<CombineGenes>();

		private static GeneFunctionManager geneFunctionManager;

		private void Awake()
		{
			geneFunctionManager = this;
		}

		public static (bool, Gene) FindCombineGenes(Gene _first, Gene _second)
		{
			bool canCombine = false;
			Gene combination = null;
			foreach (CombineGenes entity in geneFunctionManager.combinations)
			{
				(canCombine, combination) = entity.ReturnGeneAndTrue(_first, _second);
				if (canCombine)
				{
					break;
				}
			}
			return (canCombine, combination);
		}
	}

}
