﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour {

	public static List<RoomObject> Objects = new List<RoomObject>();

	void OnEnable() {
		Objects.Add(this);
	}

	void OnDisable() {
		Objects.Remove(this);
	}
}
