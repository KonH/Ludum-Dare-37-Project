using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.SaveSystem;

public class GameController : IGame {

	public void Init() {}

	public void PostInit() {}

	GameMode _currentMode = GameMode.Survival;
	int      _currentScore;
	bool     _canSpell;

	public void SelectMode(GameMode mode) {
		_currentMode = mode;
		Log.MessageFormat("Select mode: {0}", -1, mode);
	}

	public GameMode GetCurrentMode() {
		return _currentMode;
	}

	public void CalculateScore(float time) {
		if( GetCurrentMode() == GameMode.Story ) {
			_currentScore = 0;
			return;
		}
		_currentScore = Mathf.FloorToInt(time) * 50;
		if( GetBestScore() < _currentScore ) {
			var saveNode = Save.GetNode<SaveNode>();
			if( saveNode == null ) {
				saveNode = new SaveNode();
			}
			saveNode.BestScore = _currentScore;
			Save.SaveNode(saveNode);
		}
		ResetRoomState();
	}

	public int GetCurrentScore() {
		return _currentScore;
	}

	public int GetBestScore() {
		var saveNode = Save.GetNode<SaveNode>();
		return saveNode != null ? saveNode.BestScore : 0;
	}

	public bool CanGetDoor() {
		return GetCurrentMode() != GameMode.Story;
	}

	public bool IsAutoSpellsEnabled() {
		if( GetCurrentMode() == GameMode.Story ) {
			return _canSpell;
		}
		return true;
	}

	void ResetRoomState() {
		_canSpell = false;
	}

	public void SetAutoSpells(bool value) {
		_canSpell = value;
	}
}
