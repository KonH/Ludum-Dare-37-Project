using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItem : MonoBehaviour {
	public static List<FloorItem> Items = new List<FloorItem>();

	public FloorType Type;

	void OnEnable() {
		Items.Add(this);
	}

	void OnDisable() {
		Items.Remove(this);
	}
}
