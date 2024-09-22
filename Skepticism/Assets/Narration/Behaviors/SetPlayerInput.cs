using UnityEngine;

public class SetPlayerInput : StateMachineBehaviour {
	public bool receivesInput;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.Player.ReceivesInput = receivesInput;
	}
}
