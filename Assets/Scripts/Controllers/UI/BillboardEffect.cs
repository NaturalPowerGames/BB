using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
	private void Update()
	{
		transform.LookAt(Camera.main.transform);
	}
}
