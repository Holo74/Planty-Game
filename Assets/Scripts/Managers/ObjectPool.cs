using Holo74.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Managers
{
	public class ObjectPool : MonoBehaviour
	{
		private static ObjectPool instance;
		[SerializeField]
		private GameObject parentObject;
		private List<GameObject> seedlings = new List<GameObject>(), firstStage = new List<GameObject>(), secondStage = new List<GameObject>(), thirdStage = new List<GameObject>();
		[SerializeField]
		private GameObject seedlingObject, firstStageObject, secondStageObject, thirdStageObject;
		private Vector3 away = new Vector3(99999,99999,99999);
		public enum ObjectType
		{
			seedling,
			first,
			second,
			third
		}

		private void Awake()
		{
			instance = this;
			for (int i = 0; i < 10; i++)
			{
				CreateObject(ObjectType.seedling);
			}
		}

		public static ObjectPool Instance()
		{
			return instance;
		}

		public static GameObject GetSeedling(GameObject _parentObject)
		{
			if(instance.seedlings.Count < 1)
			{
				instance.CreateObject(ObjectType.seedling);
			}
			GameObject holder = instance.seedlings[0];
			instance.seedlings.Remove(holder);
			holder.transform.parent = _parentObject.transform;
			holder.transform.localPosition = Vector3.zero;
			return holder;
		}

		public static GameObject GetFirstStage(GameObject _parentObject)
		{
			if (instance.firstStage.Count < 1)
			{
				instance.CreateObject(ObjectType.first);
			}
			GameObject holder = instance.firstStage[0];
			instance.firstStage.Remove(holder);
			holder.transform.parent = _parentObject.transform;
			holder.transform.localPosition = Vector3.zero;
			return holder;
		}

		public static GameObject GetSecondStage(GameObject _parentObject)
		{
			if (instance.secondStage.Count < 1)
			{
				instance.CreateObject(ObjectType.second);
			}
			GameObject holder = instance.secondStage[0];
			instance.secondStage.Remove(holder);
			holder.transform.parent = _parentObject.transform;
			holder.transform.localPosition = Vector3.zero;
			return holder;
		}

		public static GameObject GetThirdStage(GameObject _parentObject)
		{
			if (instance.thirdStage.Count < 1)
			{
				instance.CreateObject(ObjectType.third);
			}
			GameObject holder = instance.thirdStage[0];
			instance.thirdStage.Remove(holder);
			holder.transform.parent = _parentObject.transform;
			holder.transform.localPosition = Vector3.zero;
			return holder;
		}

		public static void Recycle(GameObject _object, Plant.StageOfGrowth growth)
		{
			switch (growth)
			{
				case Plant.StageOfGrowth.seedling:
					instance.seedlings.Add(_object);
					break;
				case Plant.StageOfGrowth.first:
					instance.firstStage.Add(_object);
					break;
				case Plant.StageOfGrowth.second:
					instance.secondStage.Add(_object);
					break;
				case Plant.StageOfGrowth.final:
					instance.thirdStage.Add(_object);
					break;
				default:
					break;
			}
			_object.transform.parent = instance.parentObject.transform;
			_object.transform.localPosition = instance.away;
		}

		public void CreateObject(ObjectType type)
		{
			GameObject holder = null;
			switch (type)
			{
				case ObjectType.seedling:
					holder = Instantiate(seedlingObject);
					seedlings.Add(holder);
					break;
				case ObjectType.first:
					holder = Instantiate(firstStageObject);
					firstStage.Add(holder);
					break;
				case ObjectType.second:
					holder = Instantiate(secondStageObject);
					secondStage.Add(holder);
					break;
				case ObjectType.third:
					holder = Instantiate(thirdStageObject);
					thirdStage.Add(holder);
					break;
				default:
					break;
			}
			holder.transform.parent = parentObject.transform;
			holder.transform.localPosition = instance.away;
		}
	}
}
