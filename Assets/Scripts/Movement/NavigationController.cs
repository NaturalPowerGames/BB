using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
	private NavMeshAgent agent;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}	
}
