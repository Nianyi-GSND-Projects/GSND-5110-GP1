using UnityEngine;

public class WaitForNextRoom : StateMachineBehaviour {
	private Room room;
	public int count = 1;
	private int walked = 0;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.speed = 0.0f;
		walked = 0;
		room = GameManager.Instance.CurrentRoom;
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(walked >= count) {
			if(walked == count) {
				animator.speed = 1.0f;
				++walked;
			}
			return;
		}
		if(GameManager.Instance.CurrentRoom != room) {
			++walked;
			room = GameManager.Instance.CurrentRoom;
		}
	}
}
