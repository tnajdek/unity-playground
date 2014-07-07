using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour {

	public static void StartClient() {
		Network.Connect("127.0.0.1", 25000);
		Debug.Log("Connecting to 127.0.0.1:2500");
	}

	void OnConnectedToServer() {
		Debug.Log("Connected to server");
	}
}
