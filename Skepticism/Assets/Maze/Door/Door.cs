using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {
	[SerializeField] private UnityEvent onOpened, onClosed;
	[SerializeField] private bool openOnStart = false;
	[SerializeField] private UnityEvent open, close;

	private bool isOpen = false;
	public bool IsOpen {
		get => isOpen;
		set {
			if(value == isOpen)
				return;

			if(isOpen = value) {
				open?.Invoke();
				Debug.Log($"{this} is opened.", this);
				onOpened?.Invoke();
			}
			else {
				close?.Invoke();
				Debug.Log($"{this} is closed.", this);
				onClosed?.Invoke();
			}
		}
	}

	protected void Start() {
		if(openOnStart)
			IsOpen = true;
	}

	#region Auxiliary functions
	public void SetHingeJoinSpringAngle(float angle) {
		if(!TryGetComponent<HingeJoint>(out var hingeJoint)) {
			Debug.LogWarning($"There is no hinge joint on {this}!", this);
			return;
		}

		var spring = hingeJoint.spring;
		spring.targetPosition = angle;
		hingeJoint.spring = spring;
	}
	#endregion
}
