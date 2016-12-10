using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType {
	Transform,
	Physics,
	Floor,
	Damage,
	Generation
}

public class Spell {
	public SpellType Type;
	public string Name;
	public Action Callback;

	public Spell(SpellType type, string name, Action callback) {
		Type = type;
		Name = name;
		Callback = callback;
	}
}
