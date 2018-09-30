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
		private Sprite nonHoverSpriteCantSelect, nonHoverSpriteCanSelect, hoverSpriteCanSelect, hoverSpriteCantSelect;
		public bool canSelect = false;

		private void Awake()
		{
			mainSelection = transform.parent.GetComponent<PlanterBoxUI>();
		}

		void Update()
		{
			DetectingMouse();
		}

		private void OnMouseEnter()
		{
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
		}

		private void OnMouseExit()
		{
			mainSelection.mainBox = -1;
			if (canSelect)
			{
				spriteSelection.sprite = nonHoverSpriteCanSelect;
			}
			else
			{
				spriteSelection.sprite = nonHoverSpriteCantSelect;
			}
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
					if (canSelect)
					{
						spriteSelection.sprite = nonHoverSpriteCanSelect;
					}
					else
					{
						spriteSelection.sprite = nonHoverSpriteCantSelect;
					}
					
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
