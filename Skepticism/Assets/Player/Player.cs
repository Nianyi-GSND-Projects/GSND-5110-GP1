using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {
	[SerializeField] private PlayerInputHandler input;
	[SerializeField] private Transform head, eye;
	[SerializeField] private CharacterController controller;
	[Range(0, 5)] public float speed = 1;

	public bool ReceivesInput {
		get => input.enabled;
		set => input.enabled = value;
	}

	public void OrientDelta(Vector2 delta) {
		Azimuth += delta.x;
		Zenith += delta.y;
	}

	public void MoveVelocity(Vector3 inputVelocity) {
		var velocity = Quaternion.LookRotation(transform.forward) * inputVelocity;
		velocity *= speed;
		controller.SimpleMove(velocity);
	}

	public float Azimuth {
		get {
			Vector3 forward = transform.forward;
			return Mathf.Atan2(forward.x, forward.z);
		}
		set {
			float degree = value * 180 / Mathf.PI;
			// Needs to be refined to support unusual cases.
			transform.rotation = Quaternion.Euler(0, degree, 0);
		}
	}

	public float Zenith {
		get {
			Vector3 forward = head.forward;
			float y = forward.y;
			forward.y = 0;
			return Mathf.Atan2(y, forward.magnitude);
		}
		set {
			float degree = value * 180 / Mathf.PI;
			degree = Mathf.Clamp(degree, -90, 90);
			head.localRotation = Quaternion.Euler(-degree, 0, 0);
		}
	}

	public void Interact() {
		Ray ray = new(eye.position, eye.forward);
		if(!Physics.Raycast(ray, out RaycastHit hit))
			return;
		var target = hit.collider.transform;
		if(!target.TryGetComponent<Interactable>(out var interactable))
			return;
		interactable.Interact();
	}
}
