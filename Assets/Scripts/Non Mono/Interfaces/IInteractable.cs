using UnityEngine;

public interface IInteractable
{
	Vector3 GetLocation();
	bool Interact<T>(T other);
	void StopInteraction<T>(T other);
}
