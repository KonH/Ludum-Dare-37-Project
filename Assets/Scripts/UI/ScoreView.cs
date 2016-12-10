using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreView : MonoBehaviour {

	string _format;
	Text _text;

	void Awake() {
		_text = GetComponent<Text>();
		_format = _text.text;
	}

	public void UpdateScore() {
		var current = Game.GetCurrentScore();
		var best = Game.GetBestScore();
		if( current <= 0 ) {
			_text.text = "";
		}
		_text.text = string.Format(_format, current, best);
	}
}
