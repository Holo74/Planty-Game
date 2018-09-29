using Holo74.Plants.Genes;
using UnityEngine;

namespace Holo74.Plants
{
	public class Plant : MonoBehaviour
	{
		[SerializeField]
		private GenePool genes = new GenePool();

		private bool watered, weeded;

		private float delta;

		public delegate void PlantGrown(Plant plant);
		private PlantGrown PlantGrew;

		public enum StageOfGrowth
		{
			seedling,
			first,
			second,
			third,
			final
		}
		private StageOfGrowth currentGrowth = StageOfGrowth.seedling;

		public Plant(Gene startGene)
		{
			genes.ModifyGenes(startGene);
		}

		private void Update()
		{
			if(genes.GetAllGenes().Count > 0)
			{
				if (delta > genes.GrowthTime())
				{
					delta = 0;
					if (watered && weeded)
					{
						GrowingUp();
					}
				}
				delta += Time.deltaTime;
			}
		}
		
		[ContextMenu("Grow Up")]
		private void GrowingUp()
		{
			switch (currentGrowth)
			{
				case StageOfGrowth.seedling:
					currentGrowth = StageOfGrowth.first;
					ImageScaling(.2f);
					break;
				case StageOfGrowth.first:
					currentGrowth = StageOfGrowth.second;
					ImageScaling(.4f);
					break;
				case StageOfGrowth.second:
					currentGrowth = StageOfGrowth.third;
					ImageScaling(.7f);
					break;
				case StageOfGrowth.third:
					currentGrowth = StageOfGrowth.final;
					ImageScaling(1f);
					break;
				case StageOfGrowth.final:
					break;
				default:
					break;
			}
			PlantGrew?.Invoke(this); //Only runs if plant grew is not null
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

		private void ImageScaling(float _scale)
		{
			Vector3 scale = Vector3.one * _scale;
			transform.localScale = scale;
		}

		public void PlantGrewUp(PlantGrown function)
		{
			PlantGrew = function;
		}

		public GenePool GetGenes()
		{
			return genes;
		}
	}

}
