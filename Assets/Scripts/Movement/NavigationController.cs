using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
	private NavMeshAgent agent;

	public Transform destination;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	private void Start()
	{
		agent.SetDestination(destination.position);
	}
}
