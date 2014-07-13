using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
	public Vector3 destination;
	private float turnSmoothing = 15f;
	private Animator anim;
	private NavMeshAgent nav;

	// Use this for initialization
	void Start() {
		// this is server-only script.
		if(Network.isClient) {
			this.enabled = false;
			anim = GetComponent<Animator>();
			anim.applyRootMotion = false;
			GetComponent<CapsuleCollider>().enabled = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	void Awake() {
		destination = transform.position;
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(destination);
		nav.speed = 6f;

		if(nav.remainingDistance < nav.stoppingDistance) {
			nav.Stop();
		}
	}
	
//	bool Rotating() {
//		Vector3 targetVector = destination - transform.position;
//		float distance = Vector3.Distance(rigidbody.position, destination);
//		float diff = Mathf.Deg2Rad * Vector3.Angle(transform.forward, targetVector);
//		float prevAngularSpeed = anim.GetFloat("AngularSpeed");
//
//		float dot = Vector3.Dot(transform.forward.normalized, targetVector.normalized);
//		Debug.Log("distance: " + distance);
//		Debug.Log("dot " + dot);
//		Debug.Log("angle: " + diff);
//
//		if(distance > 0.1f)  {
//			anim.SetFloat("AngularSpeed", dot);
//			if(Mathf.Abs(dot) < 0.5f) {
//				//transform.LookAt(targetVector);
//				//transform.rotation.SetLookRotation(targetVector);
//				anim.SetFloat("AngularSpeed", 0f);
//				return true;
//			} else {
//				return false;
//			}
//		} else {
//			anim.SetFloat("AngularSpeed", 0f);
//			return true;
//		}
//	}
//
//	void Moving(bool rightDirection) {
//		float distance = Vector3.Distance(rigidbody.position, destination);
//		float curSpeed = anim.GetFloat("Speed");
//		float maxSpeed = 6.0f;
//		float targetSpeed;
//
//		//Debug.Log("Walking");
//		//Debug.Log(distance);
//
//		if(!rightDirection) {
//			targetSpeed = Mathf.Lerp(curSpeed, 0f, Time.deltaTime);
//			anim.SetFloat("Speed", targetSpeed);
//		} else if(distance > 0.5f) {
//			targetSpeed = Mathf.Lerp(curSpeed, maxSpeed, Time.deltaTime);
//			anim.SetFloat("Speed", targetSpeed);
//		} else if(distance > 0.25f) {
//			targetSpeed = Mathf.Lerp(curSpeed, 0f, Time.deltaTime);
//			anim.SetFloat("Speed", targetSpeed);
//		} else {
//			anim.SetFloat("Speed", 0f);
//		}
//	}
}
