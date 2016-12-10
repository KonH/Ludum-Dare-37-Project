using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TaskTimeView : MonoBehaviour {

	Text _text;

	void Start () {
		_text = GetComponent<Text>();
	}

	void Update () {
		var tm = TaskManager.Instance;
		if( tm.HasTimer ) {
			_text.enabled = true;
			_text.text = string.Format("00:{0:00}", Mathf.FloorToInt(tm.MaxTimerValue - tm.TimerValue));
		} else {
			_text.enabled = false;
		}
	}
}
