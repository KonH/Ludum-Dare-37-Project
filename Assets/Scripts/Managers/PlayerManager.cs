using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour {
	public static PlayerManager Instance;

	public PlayerObject Player;
	[HideInInspector]
	public Transform PlayerTransform;
	[HideInInspector]
	public Destroyable PlayerDestroyable;
	[HideInInspector]
	public CollisionTracker ExitTracker;

	public UnityEvent OnScoresUpdated;

	void Awake() {
		Instance = this;
		PlayerTransform = Player.transform;
		PlayerDestroyable = Player.GetComponent<Destroyable>();
		ExitTracker = Player.GetComponent<CollisionTracker>();
		PlayerDestroyable.OnDestroy.AddListener(() => OnGameEnded());
		ExitTracker.OnEnter.AddListener(() => OnGameEnded());
	}

	void OnGameEnded() {
		Game.CalculateScore(Time.timeSinceLevelLoad);
		OnScoresUpdated.Invoke();
	}
}
