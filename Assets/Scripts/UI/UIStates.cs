using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStates : MonoBehaviour {
	public GameObject Game;
	public GameObject Lose;
	public GameObject Win;

	void Start() {
		SetState(true, false, false);
		var pm = PlayerManager.Instance;
		pm.PlayerDestroyable.OnDestroy.AddListener(() => OnLost());
		pm.ExitTracker.OnEnter.AddListener(() => OnWin());
	}

	void OnLost() {
		SetState(false, true, false);
	}

	void OnWin() {
		SetState(false, false, true);
	}

	void SetState(bool game, bool lose, bool win) {
		Game.SetActive(game);
		Lose.SetActive(lose);
		Win.SetActive(win);
	}
}
