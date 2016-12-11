using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIStates : MonoBehaviour {
	public GameObject Game;
	public GameObject Lose;
	public GameObject Win;
	public Image BlackScreen;

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
		SetState(Game, game);
		SetState(Lose, lose);
		SetState(Win, win);
		if( win || lose ) {
			var color = BlackScreen.color;
			color.a = 1f;
			BlackScreen.DOColor(color, 1f);
		}
	}

	void SetState(GameObject go, bool state) {
		if( go.activeInHierarchy != state ) {
			go.SetActive(state);
			go.transform.localScale = Vector3.zero;
			go.transform.DOScale(1, 0.25f);
		}
	}
}
