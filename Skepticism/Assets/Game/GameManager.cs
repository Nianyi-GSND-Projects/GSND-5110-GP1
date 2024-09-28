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
	[SerializeField] private Room endingRoom, pinkRoom, yellowRoom;
	[SerializeField] private UnityEvent onStart;
	[SerializeField] private CinemachineVirtualCamera playerCamera, topCamera;
	[SerializeField] private float startPeekTime = 1.0f;
	[SerializeField] private Transform endingUi;

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
		stateMachine.SetBool("Is In Pink Room", room == pinkRoom);
		stateMachine.SetBool("Is In Yellow Room", room == yellowRoom);
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
		yield return new WaitForSeconds(2.0f);

		player.ReceivesInput = true;
		onStart.Invoke();
		stateMachine.enabled = true;
	}
	#endregion

	#region Narration
	[SerializeField] private AudioSource narrationSource;
	[SerializeField] private Transform narrationUi;
	[SerializeField] private UnityEngine.UI.Text narrationText;
	private Coroutine playingCoroutine;

	public void StopCurrentNarrationLine() {
		narrationSource.Stop();
		narrationUi.gameObject.SetActive(false);
		if(playingCoroutine != null) {
			StopCoroutine(playingCoroutine);
			playingCoroutine = null;
		}
	}

	public void PlayNarrationLine(NarrationLine line) {
		StopCurrentNarrationLine();
		playingCoroutine = StartCoroutine(NarrationLinePlayingCoroutine(line));
	}

	private static string RegulateNarrationLine(string input) {
		return input.Replace("\n", " ");
	}

	private System.Collections.IEnumerator NarrationLinePlayingCoroutine(NarrationLine line) {
		narrationUi.gameObject.SetActive(true);
		narrationText.text = "";

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

		float startTime = Time.time;
		for(int i = 0; i < (line.subtitleLines?.Count ?? 0); ++i) {
			var sl = line.subtitleLines[i];
			narrationText.text = RegulateNarrationLine(sl.text);
			if(Time.time - startTime > duration)
				break;
			float waitTime = duration - sl.startTime;
			if(i < line.subtitleLines.Count - 1)
				waitTime = Mathf.Min(waitTime, line.subtitleLines[i + 1].startTime - sl.startTime);
			yield return new WaitForSeconds(waitTime);
		}

		narrationUi.gameObject.SetActive(false);
	}
	#endregion

	#region Misc
	public Player Player => player;

	public void TeleportPlayer() {
		var cc = player.GetComponent<CharacterController>();
		cc.enabled = false;
		player.transform.SetPositionAndRotation(teleportDestination.position, teleportDestination.rotation);
        cc.enabled = true;
        Debug.Log("Player teleported.");
	}

	private bool hasEnteredMidGame = false;
	public bool HasEnteredMidGame => hasEnteredMidGame;
	public void MarkMidGameState() {
		hasEnteredMidGame = true;
		stateMachine.SetBool("Has Entered MG", true);
	}

	public void EnterEnding(int ending) {
		player.ReceivesInput = false;
		stateMachine.enabled = false;
		endingUi.gameObject.SetActive(true);
		endingUi.GetChild(ending - 1).gameObject.SetActive(true);
	}
	#endregion
}
