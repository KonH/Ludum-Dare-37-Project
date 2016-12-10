using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers;

public enum GameMode {
	Unknown,
	Story,
	Survival
}

public class Game : ControllerHelper<IGame> {

	public static void SelectMode(GameMode mode) {
		if( Instance != null ) {
			Instance.SelectMode(mode);
		}
	}

	public static GameMode GetCurrentMode() {
		if( Instance != null ) {
			return Instance.GetCurrentMode();
		}
		return GameMode.Unknown;
	}

	public static void CalculateScore(float time) {
		if( Instance != null ) {
			Instance.CalculateScore(time);
		}
	}

	public static int GetCurrentScore() {
		if( Instance != null ) {
			return Instance.GetCurrentScore();
		}
		return 0;
	}

	public static int GetBestScore() {
		if( Instance != null ) {
			return Instance.GetBestScore();
		}
		return 0;
	}

	public static bool CanGetDoor() {
		if ( Instance != null ) {
			return Instance.CanGetDoor();
		}
		return true;
	}

	public static bool IsAutoSpellsEnabled() {
		if( Instance != null ) {
			return Instance.IsAutoSpellsEnabled();
		}
		return true;
	}

	public static void SetAutoSpells(bool value) {
		if ( Instance != null ) {
			Instance.SetAutoSpells(value);
		}
	}
}
