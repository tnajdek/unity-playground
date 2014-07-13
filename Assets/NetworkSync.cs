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
		if (stream.isWriting) {
			animatorSpeed = anim.GetFloat("Speed");;
			animatorAngularSpeed = anim.GetFloat("AngularSpeed");
			stream.Serialize(ref animatorSpeed);
			stream.Serialize(ref animatorAngularSpeed);
		} else {
			stream.Serialize(ref animatorSpeed);
			stream.Serialize(ref animatorAngularSpeed);
			anim.SetFloat("Speed", animatorSpeed);
			anim.SetFloat("AngularSpeed", animatorAngularSpeed);
		}
	}
}
