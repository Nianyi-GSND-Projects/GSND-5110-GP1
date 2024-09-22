using UnityEngine;

public class MarkMidGameState : StateMachineBehaviour {
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.MarkMidGameState();
	}
}
