using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTracker : MonoBehaviour {
	public UnityEvent OnEnter;
	public string TagFilter;

	void OnTriggerEnter(Collider other) {
		if( other.GetComponent<Collider>().tag == TagFilter ) {
			OnEnter.Invoke();
		}
	}
}
