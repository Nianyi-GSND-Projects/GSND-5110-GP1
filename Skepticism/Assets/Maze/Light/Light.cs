using UnityEngine;

public class Light : MonoBehaviour {
	[SerializeField] private Color color = Color.white;
	[SerializeField] private float intensity = 1000.0f;
	[SerializeField] private new Renderer renderer;
	[SerializeField] private bool isOn = false;

	public Color Color {
		get => color;
		set {
			color = value;
			IsOn = IsOn;
		}
	}

	public float Intensity {
		get => intensity;
		set {
			intensity = value;
			IsOn = IsOn;
		}
	}

	public bool IsOn {
		get => isOn;
		set {
			if(!GameManager.Instance.HasEnteredMidGame)
				value = false;

			isOn = value;
			if(renderer.material != null) {
				Color emission = isOn ? color : Color.black;
				emission *= intensity;
				renderer.material.SetColor("_EmissiveColor", emission);
			}
		}
	}

	protected void Start() {
		IsOn = IsOn;
	}
}
