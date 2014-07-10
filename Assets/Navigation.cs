using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
	public Vector3 destination;
	private float turnSmoothing = 15f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(destination != null) {
			Rotating();
		}
	
	}

	void Rotating() {
		Quaternion targetRotation = Quaternion.LookRotation(destination, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		transform.rotation = newRotation;
		Debug.Log(newRotation);
	}
}
