using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTracker : MonoBehaviour {
	public UnityEvent OnEnter;
	public UnityEvent OnExit;
	public string TagFilter;

	void OnTriggerEnter(Collider other) {
		if( other.tag == TagFilter ) {
			OnEnter.Invoke();
		}
	}

	void OnTriggerExit(Collider other) {
		if( other.tag == TagFilter ) {
			OnExit.Invoke();
		}
	}
}
