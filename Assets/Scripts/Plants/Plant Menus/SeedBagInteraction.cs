using Holo74.Hud.Interfaces;
using Holo74.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Interactables
{
	public class SeedBagInteraction : MonoBehaviour, IInteracting
	{
		private LayerMask interactable;
		private RaycastHit bag;
		[SerializeField]
		private Material baseMaterial, hovering;
		private Renderer rendererChanger;

		private void Awake()
		{
			rendererChanger = GetComponent<Renderer>();
		}

		public void Interacting()
		{
			SeedBagManager.Instance().ActivateBag();
		}

		private void OnMouseOver()
		{
			rendererChanger.material = hovering;
		}

		private void OnMouseExit()
		{
			rendererChanger.material = baseMaterial;
		}
	}

}
