using UnityEngine;
using UnityEngine.UI;

public class StartRoom : MonoBehaviour {
	[SerializeField] private RectMask2D startButonMask;
	[SerializeField] private NaniCore.DelayedLogic delayedLogic;

	public void PlayStartingAnimation() {
		StartCoroutine(StartingAnimation(delayedLogic.delayTime));
	}

	private System.Collections.IEnumerator StartingAnimation(float duration) {
		for(float startTime = Time.time, passedTime, t;
			(t = (passedTime = Time.time - startTime) / duration) < 1.0f;
			) {
			var padding = startButonMask.padding;
			padding.x = t * startButonMask.rectTransform.rect.width;
			startButonMask.padding = padding;

			yield return new WaitForEndOfFrame();
		}
	}
}
