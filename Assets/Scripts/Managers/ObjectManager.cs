using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

public class ObjectManager : MonoBehaviour {

	public static ObjectManager Instance;

	public List<RoomObject> Prefabs;
	public GameObject BoomPrefab;
	public GameObject SmallBoomPrefab;
	public List<FloorItem> FloorPrefabs; 

	List<GameObject> _tmpPrefabs = new List<GameObject>();

	void Awake() {
		Instance = this;
	}
		
	public GameObject GetPrefabExcept(ObjectType type) {
		_tmpPrefabs.Clear();
		for( int i = 0; i < Prefabs.Count; i++ ) {
			var prefab = Prefabs[i];
			if( prefab.Type != type ) {
				_tmpPrefabs.Add(prefab.gameObject);
			}
		}
		return RandomUtils.GetItem(_tmpPrefabs);
	}

	public GameObject GetPrefabExcept(FloorType type) {
		_tmpPrefabs.Clear();
		for( int i = 0; i < FloorPrefabs.Count; i++ ) {
			var prefab = FloorPrefabs[i];
			if( prefab.Type != type ) {
				_tmpPrefabs.Add(prefab.gameObject);
			}
		}
		return RandomUtils.GetItem(_tmpPrefabs);
	}

	public GameObject TransformObject(GameObject oldObject, GameObject newObject) {
		oldObject.SetActive(false);
		var instance = Instantiate(newObject, oldObject.transform.position, oldObject.transform.rotation) as GameObject;
		instance.transform.SetParent(oldObject.transform.parent, true);
		return instance;
	}

	public GameObject CreateObject(GameObject prefab, Vector3 position) {
		var instance = Instantiate(prefab, position, Quaternion.identity) as GameObject;
		return instance;
	}
}
