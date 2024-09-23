using UnityEngine;

public class EnterEnding : StateMachineBehaviour {
	public int ending = 0;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.EnterEnding(ending);
	}
}
