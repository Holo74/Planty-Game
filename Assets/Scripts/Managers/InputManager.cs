using Holo74.Hud.Interfaces;
using Holo74.Managers.InputOptions;
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
		private Gene[] startingGene, startingGene2;
		private Seeds startingSeed, startingSeed2;
		[SerializeField]
		private LayerMask canSelect;
		private RaycastHit selection;
		private InHouseCameraController inHouseCamera;

		private void Awake()
		{
			instance = this;
			startingSeed = new Seeds(startingGene);
			startingSeed2 = new Seeds(startingGene2);
			inHouseCamera = GetComponent<InHouseCameraController>();
		}

		void Update()
		{
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			MovingCameraInHouse();
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
				else
				{
					HoldingObjectManager.Instance().EmptyHands();
				}
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				SeedBagManager.AddSeeds(startingSeed);
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				SeedBagManager.AddSeeds(startingSeed2);
			}
		}

		private void MovingCameraInHouse()
		{
			if (Input.GetKey(KeyCode.A))
			{
				inHouseCamera.MoveCamera(-Time.deltaTime, InHouseCameraController.Positions.x);
			}
			if (Input.GetKey(KeyCode.S))
			{
				inHouseCamera.MoveCamera(-Time.deltaTime, InHouseCameraController.Positions.z);
			}
			if (Input.GetKey(KeyCode.D))
			{
				inHouseCamera.MoveCamera(Time.deltaTime, InHouseCameraController.Positions.x);
			}
			if (Input.GetKey(KeyCode.W))
			{
				inHouseCamera.MoveCamera(Time.deltaTime, InHouseCameraController.Positions.z);
			}
			if (Input.GetKey(KeyCode.Q))
			{
				inHouseCamera.MoveCamera(-Time.deltaTime, InHouseCameraController.Positions.y);
			}
			if (Input.GetKey(KeyCode.E))
			{
				inHouseCamera.MoveCamera(Time.deltaTime, InHouseCameraController.Positions.y);
			}
		}

		public static InputManager Instance()
		{
			return instance;
		}
	}

}
