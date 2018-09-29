using UnityEngine;

namespace Holo74.Managers
{
	public class InputManager : MonoBehaviour
	{
		private static InputManager instance;
		public static Ray mouseRay;

		private void Awake()
		{
			instance = this;
		}

		void Update()
		{
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		}

		public static InputManager Instance()
		{
			return instance;
		}
	}

}
