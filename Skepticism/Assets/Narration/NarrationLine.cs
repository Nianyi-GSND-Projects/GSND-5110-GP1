using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game/NarrationLine")]
public class NarrationLine : ScriptableObject {
	public AudioClip clip;
	[System.Serializable]
	public class SubtitleLine {
		public float endTime;
		public string text;
	}
	public List<SubtitleLine> subtitleLines;
}
