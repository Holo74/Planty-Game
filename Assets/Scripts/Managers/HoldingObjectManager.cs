using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Managers
{
	public class HoldingObjectManager : MonoBehaviour
	{
		public enum ObjectInHands
		{
			Seed,
			WaterCan,
			Hoe,
			Empty
		}
		[HideInInspector]
		public ObjectInHands holding = ObjectInHands.Empty;
		[HideInInspector]
		public bool holdingSomething;

		private static HoldingObjectManager instance;
		public static HoldingObjectManager Instance()
		{
			return instance;
		}

		private void Awake()
		{
			instance = this;
		}

		public void EmptyHands()
		{
			switch (holding)
			{
				case ObjectInHands.Seed:
					SeedBagManager.ResetSelectedSeed();
					break;
				case ObjectInHands.WaterCan:
					break;
				case ObjectInHands.Hoe:
					break;
				case ObjectInHands.Empty:
					break;
				default:
					break;
			}
			holding = ObjectInHands.Empty;
		}

		public bool GrabingSomething(ObjectInHands holding)
		{
			bool canHold = false;
			if (!holdingSomething)
			{
				this.holding = holding;
				canHold = true;
			}
			return canHold;
		}
	}

}
