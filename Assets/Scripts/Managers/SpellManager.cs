using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UDBase.Utils;
using DG.Tweening;

public class SpellManager : MonoBehaviour {

	[System.Serializable]
	public class SpellEvent : UnityEvent<string>
	{
	}

	public static SpellManager Instance;

	public float SizeDelta;

	public SpellEvent OnSpellCast;

	List<Spell> _spells = new List<Spell>();

	void Awake() {
		Instance = this;
		CreateSpells();
	}

	void AddSpell(string name, Action callback) {
		_spells.Add(new Spell(name, callback));
	}

	void CreateSpells() {
		AddSpell("Something changed!", () => Spell_Transform(true));
		AddSpell("Things are changed!", Spell_MassTransform);
		AddSpell("Boom!", () => Spell_Boom(true, true));
		AddSpell("Kaboom!", Spell_Kaboom);
		AddSpell("Shake everything!", Spell_RoomShake);
		AddSpell("Let's move!", Spell_RandomForces);
		AddSpell("Upside-down!", Spell_GravityChange);
		AddSpell("Bevare of holes!", () => Spell_FloorChange(true));
		AddSpell("Holes everywhere!", Spell_MassFloorChange);
		AddSpell("Fresh meat!", () => Spell_Generate(true));
		AddSpell("Incoming forces!", Spell_MassGenerate);
	}

	void Spell_Transform(bool look) {
		var om = ObjectManager.Instance;
		var sourceObj = RandomUtils.GetItem(RoomObject.Objects);
		if( sourceObj != null ) {
			var randObj = ObjectManager.Instance.GetPrefabExcept(sourceObj.Type);
			if( randObj ) {
				var result = om.TransformObject(sourceObj.gameObject, randObj);
				if( look ) {
					CameraManager.Instance.LookAt(result.transform);
				}
			}
		}
	}

	void Spell_MassTransform() {
		MultiplySpell(() => Spell_Transform(false));
	}

	Vector3 GetRandomPosition() {
		var x = UnityEngine.Random.Range(-SizeDelta, SizeDelta);
		var y = 0;
		var z = UnityEngine.Random.Range(-SizeDelta, SizeDelta);
		return new Vector3(x, y, z);
	}

	void Spell_Boom(bool big, bool look) {
		var position = GetRandomPosition();
		var om = ObjectManager.Instance;
		var result = om.CreateObject(big ? om.BoomPrefab : om.SmallBoomPrefab, position);
		if( look ) {
			CameraManager.Instance.LookAt(result.transform);
		}
	}

	void Spell_Kaboom() {
		MultiplySpell(() => Spell_Boom(false, false));
	}

	void Spell_RoomShake() {
		var force = Vector3.up * 500;
		var rbs = FindObjectsOfType<Rigidbody>();
		for( int i = 0; i < rbs.Length; i++ ) {
			rbs[i].AddForce(force);
		}
	}

	void Spell_FloorChange(bool look) {
		var om = ObjectManager.Instance;
		var sourceObj = RandomUtils.GetItem(FloorItem.Items);
		if( sourceObj != null ) {
			var randObj = ObjectManager.Instance.GetPrefabExcept(sourceObj.Type);
			if( randObj ) {
				var result = om.TransformObject(sourceObj.gameObject, randObj);
				if( look ) { 
					CameraManager.Instance.LookAt(result.transform);
				}
			}
		}
	}

	void Spell_MassFloorChange() {
		MultiplySpell(() => Spell_FloorChange(false));
	}

	void Spell_Generate(bool look) {
		var position = GetRandomPosition() + Vector3.up * 3;
		var om = ObjectManager.Instance;
		var prefab = RandomUtils.GetItem(om.Prefabs).gameObject;
		var result = om.CreateObject(prefab, position);
		if( look ) {
			CameraManager.Instance.LookAt(result.transform);
		}
	}

	void Spell_MassGenerate() {
		MultiplySpell(() => Spell_Generate(false));
	}
		
	float GetRandomValue() {
		return UnityEngine.Random.Range(-1.0f, 1.0f);
	}

	Vector3 GetRandomDirection() {
		return new Vector3(
			GetRandomValue(),
			GetRandomValue(),
			GetRandomValue()
		);
				
	}

	void Spell_RandomForces() {
		var force = 500;
		var rbs = FindObjectsOfType<Rigidbody>();
		for( int i = 0; i < rbs.Length; i++ ) {
			rbs[i].AddForce(force * GetRandomDirection());
		}
	}

	void Spell_GravityChange() {
		var prevValue = Physics.gravity;
		Physics.gravity = -Physics.gravity;
		var seq = DOTween.Sequence();
		seq.AppendInterval(1);
		seq.AppendCallback(() => Physics.gravity = Vector3.zero);
		seq.AppendInterval(0.5f);
		seq.AppendCallback(() => Physics.gravity = prevValue);
	}

	void MultiplySpell(Action action, int count = 5, float interval = 0.25f) {
		var seq = DOTween.Sequence();
		for( int i = 0; i < count; i++) {
			seq.AppendCallback(() => action.Invoke());
			seq.AppendInterval(interval);
		}
	}

	public void ApplySpell() {
		var spell = RandomUtils.GetItem(_spells);
		spell.Callback.Invoke();
		OnSpellCast.Invoke(spell.Name);
	}
}
