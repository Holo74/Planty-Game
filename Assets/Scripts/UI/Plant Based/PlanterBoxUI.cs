using Holo74.Hud.Interfaces;
using Holo74.Managers;
using Holo74.Plants.Planter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Hud
{
	public class PlanterBoxUI : MonoBehaviour, IInteracting
	{
		private List<PlantSelection> plantSelections = new List<PlantSelection>();
		private Planter box;
		[SerializeField]
		private LayerMask layer;
		public int mainBox = -1;
		private bool activeLock, deactivateLock;

		private void Awake()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				plantSelections.Add(transform.GetChild(i).GetComponent<PlantSelection>());
			}
			box = GetComponent<Planter>();
		}

		private void Update()
		{
			if (Physics.Raycast(InputManager.mouseRay, 200f, layer))
			{
				if (!activeLock)
				{
					activeLock = true;
					deactivateLock = false;
					foreach (PlantSelection entity in plantSelections)
					{
						entity.ActivateUI();
					}
				}
			}
			else
			{
				if (!deactivateLock)
				{
					deactivateLock = true;
					activeLock = false;
					foreach (PlantSelection entity in plantSelections)
					{
						entity.DeactivateUI();
					}
				}
			}
		}

		public void Interacting()
		{
			if(SeedBagManager.Instance().selectedSeed != null)
			{
				if(mainBox != -1)
				{
					if (box.PlantPlant(SeedBagManager.Instance().selectedSeed.GetPlantGenes(), mainBox))
					{
						SeedBagManager.RemoveSeeds(1);
						SeedBagManager.Instance().selectedSeed = null;
						Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
					}
				}
			}
		}
	}

}
