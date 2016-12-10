using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {
	NavMeshAgent _agent;

	int _mask;

	void Start () {
		_mask = LayerMask.GetMask("Floor");
		_agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		if( !CheckGround() ) {
			_agent.enabled = false;
		} else {
			_agent.enabled = true;
			_agent.SetDestination(PlayerManager.Instance.PlayerTransform.position);
		}
	}

	bool CheckGround() {
		return Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, 3, _mask);
	}
}
