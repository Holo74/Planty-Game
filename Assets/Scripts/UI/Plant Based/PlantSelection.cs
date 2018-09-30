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
		[SerializeField]
		private SpriteRenderer spriteSelection;
		private PlanterBoxUI mainSelection;
		[SerializeField]
		private int box;
		[SerializeField]
		private Sprite nonHoverSprite, hoverSpriteCanSelect, hoverSpriteCantSelect;
		[SerializeField]
		private bool canSelect = false;

		private void Awake()
		{
			mainSelection = transform.parent.GetComponent<PlanterBoxUI>();
		}

		void Update()
		{
			DetectingMouse();
		}

		private RaycastHit hit;
		private bool hoverLock, hoverSpriteLock;
		private void DetectingMouse()
		{
			if (Physics.Raycast(InputManager.mouseRay, out hit, 200f, planterBoxs))
			{
				if(hit.transform.gameObject == gameObject)
				{
					if (!hoverSpriteLock)
					{
						hoverSpriteLock = true;
						if (canSelect)
						{
							mainSelection.mainBox = box;
							spriteSelection.sprite = hoverSpriteCanSelect;
						}
						else
						{
							mainSelection.mainBox = -1;
							spriteSelection.sprite = hoverSpriteCantSelect;
						}
						hoverLock = false;
					}
				}
			}
			else
			{
				if (!hoverLock)
				{
					hoverLock = true;
					hoverSpriteLock = false;
					mainSelection.mainBox = -1;
					spriteSelection.sprite = nonHoverSprite;
				}
			}
		}

		public void ActivateUI()
		{
			spriteSelection.gameObject.SetActive(true);
		}

		public void DeactivateUI()
		{
			spriteSelection.gameObject.SetActive(false);
		}
	}

}
