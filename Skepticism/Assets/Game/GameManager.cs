using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

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
	[SerializeField] private Room endingRoom;
	[SerializeField] private UnityEvent onStart;
	[SerializeField] private CinemachineVirtualCamera playerCamera, topCamera;
	[SerializeField] private float startPeekTime = 1.0f;

	public void IncreaseCounter(string counterName, int amount = 1) {
		var value = stateMachine.GetInteger(counterName);
		++value;
		stateMachine.SetInteger(counterName, value);
	}
	#endregion

	#region Gameplay events
	private Room currentRoom, startingRoom;
	public Room CurrentRoom => currentRoom;

	public void OnEnteredRoom(Room room) {
		if(currentRoom == null)
			startingRoom = room;
		currentRoom = room;
		stateMachine.SetBool("Is In Starting Room", currentRoom == startingRoom);

		if(hasEnteredMidGame) {
			bool doorType = room.isOnTheRightPath;
			string propertyName = doorType ? "MG Green Door Count" : "MG Red Door Count";
			IncreaseCounter(propertyName);
		}

		stateMachine.SetBool("Is In Ending Room", room == endingRoom);
	}

	public void OnExitedRoom(Room room) {
	}

	public void StartGame() {
		StartCoroutine(StartGameCoroutine());
	}

	private System.Collections.IEnumerator StartGameCoroutine() {
		player.ReceivesInput = false;

		playerCamera.enabled = false;
		topCamera.enabled = true;
		yield return new WaitForSeconds(startPeekTime);
		topCamera.enabled = false;
		playerCamera.enabled = true;
		yield return new WaitForSeconds(1.0f);

		player.ReceivesInput = true;
		stateMachine.SetBool("Game Started", true);
		onStart.Invoke();
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

	private bool hasEnteredMidGame = false;
	public void MarkMidGameState() {
		hasEnteredMidGame = true;
		stateMachine.SetBool("Has Entered MG", true);
	}
	#endregion
}
