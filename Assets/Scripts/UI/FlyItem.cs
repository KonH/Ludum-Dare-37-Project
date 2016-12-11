using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyItem : MonoBehaviour {

	public float Distance = 1;

	void Start() {
		transform.DOLocalJump(Vector3.up * Distance, 5 * Distance, 1, 0.75f).SetLoops(-1);
	}
}
