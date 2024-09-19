using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerAgent : MonoBehaviour {
	public System.Action OnEnter, OnExit;
	[SerializeField] private UnityEvent onEnter, onExit;

	public Collider Trigger => GetComponent<Collider>();

	private TriggerAgent() : base() {
		OnEnter += () => onEnter?.Invoke();
		OnExit += () => onExit?.Invoke();
	}

	protected void OnTriggerEnter(Collider other) {
		OnEnter?.Invoke();
	}

	protected void OnTriggerExit(Collider other) {
		OnExit?.Invoke();
	}
}
