using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonalisePlayer : MonoBehaviour {
	private List<Color> primeColors;
	void Awake() {
		if(Network.isClient) {
			this.enabled = false;
		}
		primeColors = new List<Color>();
		primeColors.Add(new Color(237f/255f, 28f/255f, 36f/255f));
		primeColors.Add(new Color(242f/255f, 101f/255f, 34f/255f));
		primeColors.Add(new Color(247f/255f, 148f/255f, 29f/255f));
		primeColors.Add(new Color(255f/255f, 242f/255f, 0f/255f));
		primeColors.Add(new Color(141f/255f, 199f/255f, 63f/255f));
		primeColors.Add(new Color(57f/255f, 181f/255f, 74f/255f));
		primeColors.Add(new Color(0f/255f, 166f/255f, 81f/255f));
		primeColors.Add(new Color(0f/255f, 169f/255f, 157f/255f));
		primeColors.Add(new Color(0f/255f, 174f/255f, 239f/255f));
		primeColors.Add(new Color(0f/255f, 114f/255f, 188f/255f));
		primeColors.Add(new Color(0f/255f, 84f/255f, 166f/255f));
		primeColors.Add(new Color(46f/255f, 49f/255f, 146f/255f));
		primeColors.Add(new Color(102f/255f, 45f/255f, 145f/255f));
		primeColors.Add(new Color(146f/255f, 39f/255f, 143f/255f));
		primeColors.Add(new Color(236f/255f, 0f/255f, 140f/255f));
		primeColors.Add(new Color(237f/255f, 20f/255f, 91f/255f));

		Color playerColor = primeColors[Random.Range(0, primeColors.Count)];
		Light playerLight = transform.Find("Light").GetComponent<Light>();
		playerLight.color = playerColor;
	}
}
