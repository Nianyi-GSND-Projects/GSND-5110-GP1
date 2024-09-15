using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
	[SerializeField] private TriggerAgent interiorRange, boundingRange;
	public System.Action onEnter, onExit;

	protected void Start() {
		onEnter += OnPlayerEnter;
		onExit += OnPlayerExit;

		boundingRange.onEnter += onEnter;
		interiorRange.onExit += onExit;
	}

	void OnPlayerEnter() {
		Debug.Log($"Player entered room {name}.", this);
	}

	void OnPlayerExit() {
		Debug.Log($"Player exited room {name}.", this);
	}
}
