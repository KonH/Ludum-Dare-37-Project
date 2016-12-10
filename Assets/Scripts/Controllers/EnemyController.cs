using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {

	NavMeshAgent _agent;

	// Use this for initialization
	void Start () {
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		_agent.SetDestination(PlayerManager.Instance.PlayerTransform.position);
	}
}
