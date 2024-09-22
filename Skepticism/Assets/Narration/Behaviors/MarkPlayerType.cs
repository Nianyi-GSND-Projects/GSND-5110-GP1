using UnityEngine;

public class MarkPlayerType : StateMachineBehaviour {
	public int type = 0;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetInteger("Player Type", type);
	}
}
