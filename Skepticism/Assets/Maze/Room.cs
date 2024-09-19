using UnityEngine;
using ReflectionProbeRefreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode;

public class Room : MonoBehaviour {
	[SerializeField] private TriggerAgent range;
	public System.Action onEnter, onExit;
	[SerializeField] private ReflectionProbe reflectionProbe;

	protected void Start() {
		onEnter += OnPlayerEnter;
		onExit += OnPlayerExit;

		range.OnEnter += onEnter;
		range.OnExit += onExit;
	}

	void OnPlayerEnter() {
		Debug.Log($"Player entered room {name}.", this);

		SetLightingMode(true, true);
	}

	void OnPlayerExit() {
		// No need to log here. It's only the entering that matters.
		//Debug.Log($"Player exited room {name}.", this);

		SetLightingMode(true, false);
	}

	public void SetLightingMode(bool active, bool precise) {
		if(reflectionProbe != null) {
			reflectionProbe.enabled = active;
			reflectionProbe.refreshMode = precise ? ReflectionProbeRefreshMode.EveryFrame : ReflectionProbeRefreshMode.OnAwake;
		}
	}
}
