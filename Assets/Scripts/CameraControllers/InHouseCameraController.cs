using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo74.Managers.InputOptions
{
	public class InHouseCameraController : MonoBehaviour
	{
		[SerializeField]
		private GameObject mainCamera;
		[SerializeField]
		private float xLowerConstraint, xGreaterConstraint, zLowerConstraint, zGreaterConstraint, yLowerConstraint, yGreaterConstraint, movementMod = 3f;
		private Vector3 goingToPosition;

		public enum Positions
		{
			x,
			y,
			z
		}

		public void MoveCamera(float amount, Positions direction)
		{
			switch (direction)
			{
				case Positions.x:
					goingToPosition.x = Mathf.Clamp(goingToPosition.x + amount, xLowerConstraint, xGreaterConstraint);
					break;
				case Positions.y:
					goingToPosition.y = Mathf.Clamp(goingToPosition.y + amount, yLowerConstraint, yGreaterConstraint);
					break;
				case Positions.z:
					goingToPosition.z = Mathf.Clamp(goingToPosition.z + amount, zLowerConstraint, zGreaterConstraint);
					break;
				default:
					break;
			}
		}

		private void Awake()
		{
			goingToPosition = mainCamera.transform.position;
		}

		private void Update()
		{
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, goingToPosition, Time.deltaTime);
		}
	}

}
