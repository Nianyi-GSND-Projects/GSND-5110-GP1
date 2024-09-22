using UnityEngine;

public class TeleportPlayer : StateMachineBehaviour {
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.TeleportPlayer();
	}
}
