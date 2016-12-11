using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType {
	Transform = 0,
	Physics = 1,
	Floor = 2,
	Damage = 3,
	Generation = 4,
	Bonus_Shield = 5,
	Bonus_Heal = 6,
	Bonus_Kill = 7,
	Bonus_Weapon = 8,
	SpawnBonus = 9
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
