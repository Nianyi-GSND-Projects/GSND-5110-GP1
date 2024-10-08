using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Room : MonoBehaviour {
	public bool isOnTheRightPath;
	[SerializeField] private TriggerAgent range;
	[SerializeField] private ReflectionProbe reflectionProbe;

#if UNITY_EDITOR
	protected void OnDrawGizmos() {
		if(isOnTheRightPath) {
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(transform.position + Vector3.up * 3.0f, 0.5f);
		}
	}
#endif

	protected void Start() {
		range.OnEnter += OnEntered;
		range.OnExit += OnExited;

	}

	void OnEntered() {
		Debug.Log($"Player entered room {name}.", this);

		SetLightingMode(true, true);

		GameManager.Instance.OnEnteredRoom(this);
	}

	void OnExited() {
		// No need to log here. It's only the entering that matters.
		//Debug.Log($"Player exited room {name}.", this);

		SetLightingMode(true, false);

		GameManager.Instance.OnExitedRoom(this);
	}

	public void SetLightingMode(bool active, bool precise) {
		if(reflectionProbe != null) {
			var hdrpRD = reflectionProbe.GetComponent<HDAdditionalReflectionData>();
			reflectionProbe.enabled = active;
			hdrpRD.realtimeMode = precise ? ProbeSettings.RealtimeMode.EveryFrame : ProbeSettings.RealtimeMode.OnEnable;
		}
	}
}
