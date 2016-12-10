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
		var seq = DOTween.Sequence();
		seq.AppendCallback(() => AddText("Well, you are in my house."));
		seq.AppendInterval(2);
		seq.AppendCallback(() => AddText("My chairs is cozy, but don't underestimate it."));
		seq.AppendInterval(3);
		seq.AppendCallback(() => AddText("Let me show you."));
		seq.AppendInterval(2);
		seq.AppendCallback(() => StartTransforms());
		seq.AppendInterval(30);
		seq.AppendCallback(() => StopTransforms());
		seq.AppendCallback(() => AddText("Hmm..."));
		seq.AppendInterval(1);
		seq.AppendCallback(() => AddText("You are not so weak as I expected."));
		seq.AppendInterval(2);
		seq.AppendCallback(() => AddText("You can leave this beautiful place."));
		seq.AppendInterval(2);
		seq.AppendCallback(() => OpenDoor());
	}

	void StartTransforms() {
		Game.SetAutoSpells(true);
		SpellManager.Instance.SetSpellFilter(SpellType.Transform);
		HasTimer = true;
		TimerValue = 0;
		MaxTimerValue = 30;
	}

	void StopTransforms() {
		Game.SetAutoSpells(false);
		var objects = RoomObject.Objects;
		for( int i = 0; i < objects.Count; i++ ) {
			if( objects[i].Type == ObjectType.Enemy_Close ) {
				ObjectManager.Instance.TryHide(objects[i].gameObject);
				i--;
			}
		}
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

	void AddText(string text) {
		TaskChanged.Invoke(text);
	}
}
