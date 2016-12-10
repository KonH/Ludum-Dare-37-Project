using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

public class ObjectManager : MonoBehaviour {

	public static ObjectManager Instance;

	public List<RoomObject> Prefabs;
	public GameObject BoomPrefab;

	List<RoomObject> _tmpPrefabs = new List<RoomObject>();

	void Awake() {
		Instance = this;
	}
		
	public RoomObject GetPrefabExcept(ObjectType type) {
		_tmpPrefabs.Clear();
		for( int i = 0; i < Prefabs.Count; i++ ) {
			var prefab = Prefabs[i];
			if( prefab.Type != type ) {
				_tmpPrefabs.Add(prefab);
			}
		}
		return RandomUtils.GetItem(_tmpPrefabs);
	}

	public void TransformObject(GameObject oldObject, GameObject newObject) {
		oldObject.SetActive(false);
		var instance = Instantiate(newObject, oldObject.transform.position, oldObject.transform.rotation) as GameObject;
		instance.transform.SetParent(oldObject.transform.parent, true);
	}

	public void CreateObject(GameObject prefab, Vector3 position) {
		Instantiate(prefab, position, Quaternion.identity);
	}
}
