using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
	private void Update()
	{
		var direction = transform.position - Camera.main.transform.position;
		var lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = lookRotation;
	}
}
