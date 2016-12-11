using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyItem : MonoBehaviour {
	
	void Start() {
		transform.DOLocalJump(Vector3.up, 5, 1, 0.75f).SetLoops(-1);
	}
}
