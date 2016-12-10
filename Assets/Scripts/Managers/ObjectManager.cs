using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	public static ObjectManager Instance;

	public List<GameObject> Prefabs;

	void Awake() {
		Instance = this;
	}

	public void TransformObject(GameObject oldObject, GameObject newObject) {
		oldObject.SetActive(false);
		var instance = Instantiate(newObject, oldObject.transform.position, oldObject.transform.rotation) as GameObject;
		instance.transform.SetParent(oldObject.transform.parent, true);
	}
}
