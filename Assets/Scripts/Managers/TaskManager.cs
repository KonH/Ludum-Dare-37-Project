using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour {

	public PrintText TaskText;

	[System.Serializable]
	public class TaskChangedEvent: UnityEvent<string> {}

	public TaskChangedEvent TaskChanged;

	// Use this for initialization
	void Start () {
		TaskChanged.AddListener(TaskText.SetText);
		if( Game.GetCurrentMode() == GameMode.Story ) {
			TaskChanged.Invoke("Hi there!");
		} else {
			TaskChanged.Invoke("Ready for changes?");
		}
	}
}
