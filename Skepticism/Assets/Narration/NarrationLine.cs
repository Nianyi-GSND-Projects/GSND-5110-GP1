using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/NarrationLine")]
public class NarrationLine : ScriptableObject {
	public AudioClip clip;
	[System.Serializable]
	public struct SubtitleLine {
		public float endTime;
		[NaughtyAttributes.ResizableTextArea] public string text;
	}
	public List<SubtitleLine> subtitleLines;
}
