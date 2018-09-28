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

		public void PlantPlant(Plant seedling)
		{

		}
	}

}
