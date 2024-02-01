using UnityEngine;

public class InputManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			InputEvents.OnRightMouseButtonDown?.Invoke(); //aqui se revisa el gamestate antes and shit
		}
	}
}
