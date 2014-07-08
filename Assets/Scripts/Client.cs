using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour {
	public bool playing = false;
	public string username = "Unnamed Guest";

	public static void StartClient() {
		Network.Connect("127.0.0.1", 25000);
		Debug.Log("Connecting to 127.0.0.1:2500");
	}

	void OnConnectedToServer() {
		Debug.Log("Connected to server");
	}

	void OnGUI() {
		if (Network.isClient && !playing) {
			username = GUI.TextField(new Rect(
				Screen.width/2 - 50,
				Screen.height/2 - 70,
				100, 20), username
			);

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 30, 100, 20), "Spawn")) {
				networkView.RPC("SpawnPlayer", RPCMode.Server, username);
			}

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 10, 100, 20), "Disconnect")) {
				
			}
		}
	}
}