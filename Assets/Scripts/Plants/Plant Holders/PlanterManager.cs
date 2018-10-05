using Holo74.Plants.Planters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Managers
{
	public class PlanterManager : MonoBehaviour
	{
		private int amountOfPlanterBoxes = 0;
		private List<Planter> planterBoxes = new List<Planter>();
		private int maxPlanterBoxes;
		[SerializeField]
		private GameObject[] planterSpaces;

		private void Awake()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				planterBoxes.Add(transform.GetChild(i).GetComponent<Planter>());
			}
			maxPlanterBoxes = planterSpaces.Length;
		}
	}

}
