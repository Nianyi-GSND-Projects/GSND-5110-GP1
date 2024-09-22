using UnityEngine;

public class PlayNarrationLine : StateMachineBehaviour {
	public NarrationLine line;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(line != null && line.clip != null) {
			animator.speed = 1.0f / line.clip.length;
		}
		else {
			animator.speed = 1.0f;
		}
		GameManager.Instance.PlayNarrationLine(line);
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.StopCurrentNarrationLine();
		animator.speed = 1.0f;
	}
}
