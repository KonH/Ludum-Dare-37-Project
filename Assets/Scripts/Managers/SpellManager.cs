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
	SpellType[] _filter = new SpellType[0];

	void Awake() {
		Instance = this;
		CreateSpells();
	}

	void AddSpell(SpellType type, string name, Action callback) {
		_spells.Add(new Spell(type, name, callback));
	}

	void CreateSpells() {
		AddSpell(SpellType.Transform, "Something changed!", () => Spell_Transform(false));
		AddSpell(SpellType.Transform, "Things are changed!", Spell_MassTransform);
		AddSpell(SpellType.Damage, "Boom!", () => Spell_Boom(true, false));
		AddSpell(SpellType.Damage, "Kaboom!", Spell_Kaboom);
		AddSpell(SpellType.Physics, "Shake everything!", Spell_RoomShake);
		AddSpell(SpellType.Physics, "Let's move!", Spell_RandomForces);
		AddSpell(SpellType.Physics, "Upside-down!", Spell_GravityChange);
		AddSpell(SpellType.Floor, "Bevare of holes!", () => Spell_FloorChange(false));
		AddSpell(SpellType.Floor, "Holes everywhere!", Spell_MassFloorChange);
		AddSpell(SpellType.Generation, "Fresh meat!", () => Spell_Generate(false));
		AddSpell(SpellType.Generation, "Incoming forces!", Spell_MassGenerate);
	}

	void Spell_Transform(bool look) {
		var om = ObjectManager.Instance;
		var sourceObj = RoomObject.GetRandom();
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

	bool CanSpell(Spell spell) {
		if(_filter.Length > 0 ) {
			for( int i = 0; i < _filter.Length; i++ ) {
				if( _filter[i] == spell.Type ) {
					return true;
				}
			}
			return false;
		}
		return true;
	}

	public void ApplySpell() {
		var spell = RandomUtils.GetItem(_spells);
		if( CanSpell(spell) ) {
			spell.Callback.Invoke();
			OnSpellCast.Invoke(spell.Name); 
		} else {
			ApplySpell();
		}
	}

	public void SetSpellFilter(params SpellType[] filter) {
		_filter = filter;
	}
}
