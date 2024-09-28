using UnityEngine;

public class ChooseEndingRoom : StateMachineBehaviour {
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.ShowChoiceUi();
	}
}
