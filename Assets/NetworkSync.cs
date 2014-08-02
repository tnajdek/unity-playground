using UnityEngine;
using System.Collections;

public class NetworkSync : MonoBehaviour {
	private Animator anim;
	private Interpolate interpolate;

	void Awake() {
		anim = GetComponent<Animator>();
		interpolate = GetComponent<Interpolate>();
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		float animatorSpeed = 0f;
		float animatorAngularSpeed = 0f;
		Vector3 playerColor = new Vector3(Color.black.r, Color.black.g, Color.black.b);
		Vector3 playerPosition = Vector3.zero;
		Quaternion playerRotation = Quaternion.identity;

		if (stream.isWriting) {
			animatorSpeed = anim.GetFloat("Speed");;
			animatorAngularSpeed = anim.GetFloat("AngularSpeed");
			Color pColor = transform.Find("Light").GetComponent<Light>().color;
			playerColor = new Vector3(pColor.r, pColor.g, pColor.b);
			playerPosition = transform.position;
			playerRotation = transform.rotation;

			stream.Serialize(ref animatorSpeed);
			stream.Serialize(ref animatorAngularSpeed);
			stream.Serialize(ref playerColor);
			stream.Serialize(ref playerPosition);
			stream.Serialize(ref playerRotation);
		} else {
			stream.Serialize(ref animatorSpeed);
			stream.Serialize(ref animatorAngularSpeed);
			stream.Serialize(ref playerColor);
			stream.Serialize(ref playerPosition);
			stream.Serialize(ref playerRotation);

			anim.SetFloat("Speed", animatorSpeed);
			anim.SetFloat("AngularSpeed", animatorAngularSpeed);
			Color pColor = new Color(playerColor.x, playerColor.y, playerColor.z);
			transform.Find("Light").GetComponent<Light>().color = pColor;
			//transform.position = playerPosition;
			//transform.rotation = playerRotation;
			interpolate.AddPacket(info.timestamp, playerPosition, playerRotation);
		}
	}
}
