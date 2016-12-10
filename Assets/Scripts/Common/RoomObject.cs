using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

public class RoomObject : MonoBehaviour {

	public static List<RoomObject> Objects = new List<RoomObject>();

	public ObjectType Type;

	void OnEnable() {
		Objects.Add(this);
	}

	void OnDisable() {
		Objects.Remove(this);
	}

	public static RoomObject GetRandom() {
		var random = RandomUtils.GetItem(Objects);
		if( random != null ) {
			if( random.Type == ObjectType.Door ) {
				if( Game.CanGetDoor() ) {
					return random;
				} else {
					if( Objects.Count > 1 ) {
						return GetRandom();
					}
				}
			}
		}
		return random;
	}
}
