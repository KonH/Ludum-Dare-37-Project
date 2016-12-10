using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell {
	public string Name;
	public Action Callback;

	public Spell(string name, Action callback) {
		Name = name;
		Callback = callback;
	}
}
