using UnityEngine;

public class SetBoolean : StateMachineBehaviour {
	public string propertyName;
	public bool value;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool(propertyName, value);
	}
}
