using Holo74.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Hud
{
	public class PlantSelection : MonoBehaviour
	{
		[SerializeField]
		private LayerMask planterBoxs;
		void Update()
		{
			DetectingMouse();
		}

		private void DetectingMouse()
		{
			if (Physics.Raycast(InputManager.mouseRay, 200f, planterBoxs))
			{
				Debug.Log("Found");
			}
		}
	}

}
