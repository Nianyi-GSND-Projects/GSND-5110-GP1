using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInputHandler : MonoBehaviour {
	#region Fields
	private Player player;
	[SerializeField] private PlayerInput playerInput;
	private Vector3 moveVelocity;

	public bool usesMovement = true;
	public bool usesOrientation = true;
	#endregion

	#region Life cycle
	protected void Start() {
		player = GetComponent<Player>();

		foreach(var map in playerInput.actions.actionMaps)
			map.Enable();
	}

	protected void FixedUpdate() {
		if(usesMovement) {
			player.MoveVelocity(moveVelocity);
		}
	}

	protected void OnEnable() {
		playerInput.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	protected void OnDisable() {
		playerInput.enabled = false;
		Cursor.lockState = CursorLockMode.None;
	}
	#endregion

	#region Handlers
	// Movement
	protected void OnMoveVelocity(InputValue value) {
		if(!usesMovement) {
			moveVelocity = default;
			return;
		}
		var raw = value.Get<Vector2>();
		moveVelocity.x = raw.x;
		moveVelocity.z = raw.y;
	}

	// Orientation
	protected void OnOrientDelta(InputValue value) {
		if(!usesOrientation)
			return;
		Vector2 raw = value.Get<Vector2>();
		player.OrientDelta(raw);
	}

	protected void OnInteract() {
		player.Interact();
	}
	#endregion
}