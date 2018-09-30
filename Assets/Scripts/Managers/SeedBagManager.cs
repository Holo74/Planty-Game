using Holo74.Plants.Seed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Holo74.Managers
{
	public class SeedBagManager : MonoBehaviour
	{
		private Seeds[] seedBag = new Seeds[10];
		[SerializeField]
		private int maxSeeds = 10;
		private int seedBase;
		[SerializeField]
		private Image[] seedsShown;
		private Text[] seedsAmount;
		[SerializeField]
		private Sprite defaultSeedImage;
		[SerializeField]
		private Button forward, backward;
		[SerializeField]
		private GameObject bag;

		[HideInInspector]
		public Seeds selectedSeed;
		private int selectedSeedPos;

		private static SeedBagManager instance;

		public static SeedBagManager Instance()
		{
			return instance;
		}

		private void Awake()
		{
			instance = this;
			seedsAmount = new Text[seedsShown.Length];
			for (int i = 0; i < seedsAmount.Length; i++)
			{
				seedsAmount[i] = seedsShown[i].transform.GetChild(0).GetComponent<Text>();
			}
			UpdateSeeds();
			selectedSeed = null;
		}

		public void MoveUpOne()
		{
			seedBase += 1;
			backward.interactable = true;
			if(seedBase + 5 == maxSeeds)
			{
				forward.interactable = false;
			}
			UpdateSeeds();
		}

		public void MoveDownOne()
		{
			seedBase -= 1;
			forward.interactable = true;
			if (seedBase == 0)
			{
				backward.interactable = false;
			}
			UpdateSeeds();
		}

		private void UpdateSeeds()
		{
			for (int i = 0; i < seedsShown.Length; i++)
			{
				if(seedBag[i + seedBase] != null)
				{
					seedsShown[i].sprite = seedBag[i + seedBase].GetPlantGenes().GetRandomGene(0).GetFlowerSprite();
					seedsAmount[i].text = seedBag[i + seedBase].amount.ToString();
				}
				else
				{
					seedsShown[i].sprite = defaultSeedImage;
					seedsAmount[i].text = "0";
				}
			}
		}

		public void SelectingSeed(int selection)
		{
			if(seedBag[selection + seedBase] != null && HoldingObjectManager.Instance().GrabingSomething(HoldingObjectManager.ObjectInHands.Seed))
			{
				selectedSeed = seedBag[selection + seedBase];
				Cursor.SetCursor(selectedSeed.GetPlantGenes().GetRandomGene(0).GetSeedCursor(), Vector2.zero, CursorMode.Auto);
				selectedSeedPos = selection + seedBase;
			}
		}

		public static void AddSeeds(Seeds seed)
		{
			bool added = false;
			for (int i = 0; i < instance.seedBag.Length; i++)
			{
				if(instance.seedBag[i] != null)
				{
					if (instance.seedBag[i].SameGenes(seed.GetPlantGenes()))
					{
						instance.seedBag[i].amount += seed.amount;
						instance.UpdateSeeds();
						added = true;
						break;
					}
				}
			}
			for (int i = 0; i < instance.seedBag.Length; i++)
			{
				if (!added)
				{
					if (instance.seedBag[i] == null)
					{
						instance.seedBag[i] = new Seeds(seed.GetPlantGenes().GetAllGenes().ToArray());
						instance.UpdateSeeds();
						break;
					}
				}
				
			}
			
		}

		public static bool RemoveSeeds(int amount)
		{
			bool enough = false;
			if(instance.seedBag[instance.selectedSeedPos].amount - amount >= 0)
			{
				enough = true;
				instance.seedBag[instance.selectedSeedPos].amount -= amount;
				if(instance.seedBag[instance.selectedSeedPos].amount <= 0)
				{
					instance.seedBag[instance.selectedSeedPos] = null;
				}
				instance.UpdateSeeds();
			}
			return enough;
		}

		public void DeactivateBag()
		{
			seedBase = 0;
			backward.interactable = false;
			bag.SetActive(false);
		}

		public void ActivateBag()
		{
			instance.bag.SetActive(true);
			UpdateSeeds();
		}

		public static void ResetSelectedSeed()
		{
			instance.selectedSeed = null;
			instance.selectedSeedPos = -1;
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
	}

}
