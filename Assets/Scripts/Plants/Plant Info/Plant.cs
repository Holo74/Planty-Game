using Holo74.Plants.Genes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants
{
	public class Plant : MonoBehaviour
	{
		[SerializeField]
		private GenePool genes;

		private bool watered, weeded;

		public enum StageOfGrowth
		{
			seedling,
			first,
			second,
			third,
			final
		}


	}

}
