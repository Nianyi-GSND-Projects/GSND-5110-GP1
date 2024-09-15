using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerAgent : MonoBehaviour {
	public System.Action<Collider> onEnter, onExit;

	protected void OnTriggerEnter(Collider other) {
		onEnter?.Invoke(other);
	}

	protected void OnTriggerExit(Collider other) {
		onExit?.Invoke(other);
	}
}
