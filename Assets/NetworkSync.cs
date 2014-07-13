using UnityEngine;
using System.Collections;

public class NetworkSync : MonoBehaviour {
	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		float animatorSpeed = 0f;
		float animatorAngularSpeed = 0f;
		Vector3 playerColor = new Vector3(Color.black.r, Color.black.g, Color.black.b);

		if (stream.isWriting) {
			animatorSpeed = anim.GetFloat("Speed");;
			animatorAngularSpeed = anim.GetFloat("AngularSpeed");
			Color pColor = transform.Find("Light").GetComponent<Light>().color;
			playerColor = new Vector3(pColor.r, pColor.g, pColor.b);

			stream.Serialize(ref animatorSpeed);
			stream.Serialize(ref animatorAngularSpeed);
			stream.Serialize(ref playerColor);
		} else {
			stream.Serialize(ref animatorSpeed);
			stream.Serialize(ref animatorAngularSpeed);
			stream.Serialize(ref playerColor);

			anim.SetFloat("Speed", animatorSpeed);
			anim.SetFloat("AngularSpeed", animatorAngularSpeed);
			Color pColor = new Color(playerColor.x, playerColor.y, playerColor.z);
			transform.Find("Light").GetComponent<Light>().color = pColor;
		}
	}
}
