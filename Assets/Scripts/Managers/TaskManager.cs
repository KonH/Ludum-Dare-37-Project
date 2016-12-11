using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class TaskManager : MonoBehaviour {

	public static TaskManager Instance;

	public PrintText TaskText;

	[System.Serializable]
	public class TaskChangedEvent: UnityEvent<string> {}

	public TaskChangedEvent TaskChanged;

	public bool HasTimer;
	public float TimerValue;
	public float MaxTimerValue;

	Sequence _seq;

	float _stepTime = 30f;

	void Awake() {
		Instance = this;
	}

	void Start () {
		TaskChanged.AddListener(TaskText.SetText);
		if( Game.GetCurrentMode() == GameMode.Story ) {
			StartTasks();
		} else {
			AddText("Ready for changes?");
		}
	}

	void Update() {
		if( HasTimer ) {
			TimerValue += Time.deltaTime;
			if( TimerValue > MaxTimerValue ) {
				HasTimer = false;
			}
		}
	}

	void StartTasks() {
		_seq = DOTween.Sequence();
		Text("Ben hear the voice in his head:");
		Wait(2.5f);
		Text("Well, you are in my house.");
		Wait(2.5f);
		Text("And you can't call me after this day.");
		Wait(3.5f);
		Text("My chairs is cozy, but don't underestimate it.");
		Wait(3.5f);
		Text("Let me show you.");
		Wait(2.5f);
		Action(StartEasyTransforms);
		Wait(_stepTime);
		Action(StopStep);

		Text("Hmm...");
		Wait(1.5f);
		Text("You are not so weak as I expected.");
		Wait(2.5f);
		Text("But can you solve something harder?");
		Wait(2.5f);
		Action(StartMediumTransforms);
		Wait(_stepTime/2);
		Text("Still easy.");
		Action(ShakeThings);
		Wait(_stepTime/2);
		Action(StopStep);

		Text("Ha-ha! You are tough one.");
		Wait(2.5f);
		Text("But do you now how it is if your floor is out from under the feet?");
		Wait(3.5f);
		Action(StartMediumTransforms);
		Wait(0.5f);
		Action(FloorThings);
		Wait(_stepTime);
		Action(StopStep);


		Text("Nice!");
		Wait(1.5f);
		Text("Please don't think I like to torture people.");
		Wait(4f);
		Text("This room is an very unstable magical place.");
		Wait(3.5f);
		Text("And I couldn't control it permanently.");
		Wait(3.5f);
		Text("Opps.");
		Wait(1.5f);
		Text("Sorry, but this spheres may hurts.");
		Wait(3.5f);
		Action(StartMediumTransforms);
		Wait(0.5f);
		Action(BoomThings);
		Wait(_stepTime);
		Action(StopStep);


		Text("But I can do something useful here.");
		Action(StartEasyTransforms);
		Wait(0.5f);
		Action(AddBonuses);
		Wait(_stepTime);
		Action(StopStep);

		Text("Enough preparation.");
		Wait(2.5f);
		Text("This is your last test, I have almost satisfied with your efforts.");
		Action(StartHardTransforms);
		Wait(_stepTime);
		Action(StopStep);

		Text("I have changed my mind.");
		Wait(2.5f);
		Text("Another one test you need to pass.");
		Wait(3f);
		Action(StartHardTransforms);
		Wait(_stepTime);
		Action(StopStep);

		Text("Now you can understand how to live in room like this.");
		Wait(3.5f);
		Text("So no more phone calls, alright?");
		Wait(2.5f);
		Text("You can leave this beautiful place, of course.");
		Wait(2.5f);
		Action(OpenDoor);
	}

	void StartEasyTransforms() {
		Game.SetAutoSpells(true);
		SpellManager.Instance.SetSpellFilter(SpellType.Transform);
		HasTimer = true;
		TimerValue = 0;
		MaxTimerValue = _stepTime;
	}

	void StartMediumTransforms() {
		Game.SetAutoSpells(true);
		SpellManager.Instance.SetSpellFilter(SpellType.Generation, SpellType.Transform);
		HasTimer = true;
		TimerValue = 0;
		MaxTimerValue = _stepTime;
	}

	void ShakeThings() {
		SpellManager.Instance.SetSpellFilter(SpellType.Transform, SpellType.Physics);
	}

	void FloorThings() {
		SpellManager.Instance.SetSpellFilter(SpellType.Transform, SpellType.Floor);
	}

	void StartHardTransforms() {
		Game.SetAutoSpells(true);
		SpellManager.Instance.SetSpellFilter();
		HasTimer = true;
		TimerValue = 0;
		MaxTimerValue = _stepTime;
	}

	void BoomThings() {
		SpellManager.Instance.SetSpellFilter(SpellType.Generation, SpellType.Transform, SpellType.Damage);
	}

	void AddBonuses() {
		SpellManager.Instance.SetSpellFilter(SpellType.Generation, SpellType.Transform, SpellType.SpawnBonus);
	}

	void StopStep() {
		Game.SetAutoSpells(false);
		var objects = RoomObject.Objects;
		for( int i = 0; i < objects.Count; i++ ) {
			if( objects[i].Type == ObjectType.Enemy_Close ) {
				ObjectManager.Instance.TryHide(objects[i].gameObject);
				i--;
			}
		}
		var destroyable = PlayerManager.Instance.PlayerDestroyable;
		destroyable.HP = destroyable.MaxHP;
	}

	void OpenDoor() {
		var objects = RoomObject.Objects;
		RoomObject door = null;
		for( int i = 0; i < objects.Count; i++ ) {
			if( objects[i].Type == ObjectType.Door ) {
				door = objects[i];
			}
		}
		ObjectManager.Instance.TryHide(door.gameObject);
	}

	void Text(string text) {
		_seq.AppendCallback(() => AddText(text));
	}

	void AddText(string text) {
		TaskChanged.Invoke(text);
	}

	void Wait(float time) {
		_seq.AppendInterval(time);
	}

	void Action(System.Action action) {
		_seq.AppendCallback(() => action.Invoke());
	}
}
