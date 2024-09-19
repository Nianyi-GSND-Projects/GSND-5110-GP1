using UnityEngine;

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

	#region
	[SerializeField] private Player player;
	[SerializeField] private CanvasGroup victoryScreen, deathScreen;
	[SerializeField] private Room victoryRoom;
	#endregion

	#region Gameplay events
	public void OnEnteredRoom(Room room) {
		if(room == victoryRoom)
			OnWinning();
		else {
			if(!room.isOnTheRightPath)
				OnEnteredWrongRoom();
		}
	}

	private void OnEnteredWrongRoom() {
		Debug.LogWarning("The player entered a wrong room.");
		player.ReceivesInput = false;
		deathScreen.gameObject.SetActive(true);
	}

	private void OnWinning() {
		player.ReceivesInput = false;
		victoryScreen.gameObject.SetActive(true);
	}
	#endregion
}
