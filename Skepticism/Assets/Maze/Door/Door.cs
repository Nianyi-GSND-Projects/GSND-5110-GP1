using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {
	[SerializeField] private Animator animator;
	private const string doorStatePropertyName = "Door State";
	[SerializeField] private TriggerAgent range;
	[SerializeField] private Light[] lights;
	[SerializeField] private UnityEvent onOpened, onClosed;

	protected void Start() {
		if(range != null) {
			range.OnExit += () => SetDoorState(0);
		}
	}

	public void SetDoorState(float doorState) {
		animator.SetFloat(doorStatePropertyName, doorState);

		if(GameManager.Instance.HasEnteredMidGame) {
			foreach(var light in lights) {
				if(light == null)
					continue;
				light.IsOn = doorState != 0.0f;
			}
		}
	}
}
