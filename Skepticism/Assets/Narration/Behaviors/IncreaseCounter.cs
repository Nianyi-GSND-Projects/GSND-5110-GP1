using UnityEngine;

public class IncreaseCounter : StateMachineBehaviour {
	public string counterName;
	public int amount = 1;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameManager.Instance.IncreaseCounter(counterName, amount);
	}
}
