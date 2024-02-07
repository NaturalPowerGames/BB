using UnityEngine;

public interface IInteractable
{
	Vector3 GetLocation();
	void Interact<T>(T other);
	void StopInteraction<T>(T other);
}
