using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerAgent : MonoBehaviour {
	public System.Action onEnter, onExit;

	protected void OnTriggerEnter(Collider other) {
		onEnter?.Invoke();
	}

	protected void OnTriggerExit(Collider other) {
		onExit?.Invoke();
	}
}
