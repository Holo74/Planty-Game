using Holo74.Managers;
using Holo74.Plants.Genes;
using UnityEngine;

namespace Holo74.Plants
{
	public class Plant : MonoBehaviour
	{
		[SerializeField]
		private GenePool genes = new GenePool();

		private bool watered, weeded;

		private float delta, plantWaterLevel;

		public delegate void PlantGrown(Plant plant);
		private PlantGrown PlantGrew;
		public GameObject plantMesh;



		public enum StageOfGrowth
		{
			seedling,
			first,
			second,
			final
		}
		private StageOfGrowth currentGrowth = StageOfGrowth.seedling;

		public StageOfGrowth GetCurrentGrowth()
		{
			return currentGrowth;
		}

		public Plant(Gene startGene)
		{
			genes.ModifyGenes(startGene, currentGrowth);
		}

		private void Update()
		{
			if(genes.GetAllGenes().Count > 0)
			{
				if (delta > genes.GrowthTime())
				{
					delta = 0;
					if (watered)
					{
						GrowingUp();
					}
				}
				AddTime(Time.deltaTime);
			}
		}
		
		private void AddTime(float _time)
		{
			plantWaterLevel += _time;
			delta += _time;
		}

		[ContextMenu("Grow Up")]
		private void GrowingUp()
		{
			Debug.Log("Growing up");
			switch (currentGrowth)
			{
				case StageOfGrowth.seedling:
					currentGrowth = StageOfGrowth.first;
					ObjectPool.Recycle(plantMesh, StageOfGrowth.seedling);
					plantMesh = ObjectPool.GetFirstStage(transform.parent.gameObject);
					break;
				case StageOfGrowth.first:
					currentGrowth = StageOfGrowth.second;
					ObjectPool.Recycle(plantMesh, StageOfGrowth.first);
					plantMesh = ObjectPool.GetSecondStage(transform.parent.gameObject);
					ChangingBerryColors();
					break;
				case StageOfGrowth.second:
					currentGrowth = StageOfGrowth.final;
					ObjectPool.Recycle(plantMesh, StageOfGrowth.second);
					plantMesh = ObjectPool.GetThirdStage(transform.parent.gameObject);
					ChangingBerryColors();
					break;
				case StageOfGrowth.final:
					break;
				default:
					break;
			}
			PlantGrew?.Invoke(this); //Only runs if plant grew is not null
		}

		private void ChangingBerryColors()
		{
			if(plantMesh.transform.GetChild(2).childCount == 0)
			{
				plantMesh.transform.GetChild(2).GetComponent<MeshRenderer>().material.color = genes.GetDominateGene().GetBerryColor();
			}
			else
			{
				for (int i = 0; i < plantMesh.transform.GetChild(2).childCount; i++)
				{
					plantMesh.transform.GetChild(2).GetChild(i).GetComponent<MeshRenderer>().material.color = genes.GetDominateGene().GetBerryColor();
				}
			}
		}

		[ContextMenu("Water Plant")]
		public void WaterPlant()
		{
			watered = true;
		}

		[ContextMenu("Weed Plant")]
		public void WeedPlant()
		{
			weeded = true;
		}

		[ContextMenu("Water and Weed")]
		public void WaterAndWeedPlant()
		{
			WaterPlant();
			WeedPlant();
		}

		public void PlantGrewUp(PlantGrown function)
		{
			PlantGrew = function;
		}

		public GenePool GetGenes()
		{
			return genes;
		}

		public float GetWaterLevel()
		{
			float returnValue = Mathf.Clamp(plantWaterLevel / genes.GetWaterNeed(), 0f, 1f);
			return returnValue;
		}
	}

}
