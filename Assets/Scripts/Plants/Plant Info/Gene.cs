using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Plants.Genes
{
	public abstract class Gene : ScriptableObject
	{
		[SerializeField, Range(0, 100)]
		private int priority;
		[SerializeField, Range(0, 100)]
		private int frequency;
		[SerializeField, Range(-60, 60)]
		private float growthTime;
		[SerializeField]
		private Sprite flowerSprite, seedSprite;
		[SerializeField]
		private Texture2D seedCursor;

		public enum StatusEffect
		{
			negative,
			positive,
			modifier
		}
		[SerializeField]
		private StatusEffect statusEffect;

		public float GetGrowthTime()
		{
			return growthTime;
		}

		public Sprite GetFlowerSprite()
		{
			return flowerSprite;
		}

		public Sprite GetSeedSprite()
		{
			return seedSprite;
		}

		public Texture2D GetSeedCursor()
		{
			return seedCursor;
		}

		public int GetFrequency()
		{
			return frequency;
		}

		public abstract void Effect();
		public abstract void Effect(Gene geneModifier);
	}

}
