using System;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
	private NavMeshAgent agent;
	private Action onReached;
	private bool moving;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}	

	public void MoveTo(Vector3 position, Action onReached)
	{
		agent.SetDestination(position);
		moving = true;	
		this.onReached = onReached;
	}

	private void Update()
	{
		if (moving && Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance)
		{
			moving = false;
			onReached?.Invoke();
			onReached = null;
		}
	}
}
