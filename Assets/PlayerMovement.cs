using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}
}
