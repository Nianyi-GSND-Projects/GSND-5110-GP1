using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	#region Singleton
	private static GameManager instance;
	public static GameManager Instance => instance;
	protected void Awake() {
		instance = this;
	}
	protected void OnDestroy() {
		instance = null;
	}
	#endregion

	#region Serialized fields
	[SerializeField] private Player player;
	[SerializeField] private Transform teleportDestination;
	[SerializeField] private Animator stateMachine;
	#endregion

	#region Gameplay events
	private Room currentRoom, startingRoom;
	public Room CurrentRoom => currentRoom;

	public void OnEnteredRoom(Room room) {
		if(currentRoom == null)
			startingRoom = room;
		currentRoom = room;
		stateMachine.SetBool("Is In Starting Room", currentRoom == startingRoom);
	}

	public void OnExitedRoom(Room room) {
	}
	#endregion

	#region Narration
	[SerializeField] private AudioSource narrationSource;
	private Coroutine playingCoroutine;

	public void StopCurrentNarrationLine() {
		narrationSource.Stop();
		if(playingCoroutine != null) {
			StopCoroutine(playingCoroutine);
			playingCoroutine = null;
		}
	}

	public void PlayNarrationLine(NarrationLine line) {
		StopCurrentNarrationLine();

		float duration = 1.0f;

		if(line == null)
			Debug.LogWarning("The narration line to be played is null.");
		else {
			if(line.clip == null)
				Debug.LogWarning($"The audio clip of {line} is null.");
			else {
				narrationSource.clip = line.clip;
				duration = line.clip.length;
				narrationSource.loop = false;
				narrationSource.volume = 1.0f;
				narrationSource.Play();
			}
		}

		playingCoroutine = StartCoroutine(NarrationLinePlayingCoroutine(duration));
	}

	private System.Collections.IEnumerator NarrationLinePlayingCoroutine(float duration) {
		yield return new WaitForSeconds(duration);
	}
	#endregion

	#region Misc
	public Player Player => player;

	public void TeleportPlayer() {
		player.transform.SetPositionAndRotation(teleportDestination.position, teleportDestination.rotation);
		Debug.Log("Player teleported.");
	}
	#endregion
}
