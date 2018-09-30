using Holo74.Hud.Interfaces;
using Holo74.Plants.Genes;
using Holo74.Plants.Seed;
using UnityEngine;

namespace Holo74.Managers
{
	public class InputManager : MonoBehaviour
	{
		private static InputManager instance;
		public static Ray mouseRay;
		[SerializeField]
		private Gene[] startingGene;
		private Seeds startingSeed;
		[SerializeField]
		private LayerMask canSelect;
		private RaycastHit selection;

		private void Awake()
		{
			instance = this;
			startingSeed = new Seeds(startingGene);
		}

		void Update()
		{
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.GetKeyDown(KeyCode.A))
			{
				SeedBagManager.AddSeeds(startingSeed);
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				startingSeed = null;
			}
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(mouseRay, out selection, 200f, canSelect))
				{
					IInteracting interacting = selection.transform.GetComponent<IInteracting>();
					if (interacting != null)
					{
						interacting.Interacting();
					}
				}
			}
		}

		public static InputManager Instance()
		{
			return instance;
		}
	}

}
