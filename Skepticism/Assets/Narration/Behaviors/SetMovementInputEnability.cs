using UnityEngine;

public class SetMovementInputEnability : StateMachineBehaviour {
	public bool receivesInput;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.Player.ReceivesMovementInput = receivesInput;
	}
}
