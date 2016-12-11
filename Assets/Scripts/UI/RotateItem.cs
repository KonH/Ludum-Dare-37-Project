using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour {

	public Vector3 Force;

	void Update() {
		transform.Rotate(Force);
	}
}
