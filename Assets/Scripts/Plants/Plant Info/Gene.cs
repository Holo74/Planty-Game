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

		public enum StatusEffect
		{
			negative,
			positive,
			modifier
		}
		[SerializeField]
		private StatusEffect statusEffect;

		public abstract void Effect();
		public abstract void Effect(Gene geneModifier);
	}

}
