using UnityEngine;
using ECM.Controllers;
using ECM.Common;

public class BBCharacterController : BaseCharacterController
{
	protected override void HandleInput()
	{
		base.HandleInput();
		moveDirection = moveDirection.relativeTo(Camera.main.transform);
	}
}
