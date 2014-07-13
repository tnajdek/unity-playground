using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour {
	public bool playing = false;
	public string username = "Unnamed Guest";

	private Camera cam;
	private GameObject ground;

	public static void StartClient(string serverIP) {
		Network.Connect(serverIP, 25000);
		Debug.Log("Connecting to 127.0.0.1:2500");
	}

	void OnConnectedToServer() {
		Debug.Log("Connected to server");
	}

	void OnGUI() {
		if (Network.isClient && !playing) {

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 30, 100, 20), "Spawn")) {
				networkView.RPC("SpawnPlayer", RPCMode.Server, username);
			}

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 10, 100, 20), "Disconnect")) {
				
			}
			GUI.Box(new Rect(10, 10, 100, 20), "Ping:" + Network.GetAveragePing(Network.connections[0]));
		}
	}

	void Awake() {
		cam = GameObject.FindObjectOfType<Camera>();
		ground = GameObject.Find("Ground");
	}

	void Update() {
		if (!Network.isClient || !playing) { 
			return;
		}
		float distance = 10000F;
		RaycastHit info;
		Ray vRay = cam.ScreenPointToRay(Input.mousePosition);

		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Pressed left click.");
			if(ground.collider.Raycast(vRay, out info, distance)) {
				networkView.RPC("WalkTo", RPCMode.Server, info.point);
			} else {
				Debug.Log("no collision...");
			}
		}
		
		if (Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		
		if (Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
		
	}

	[RPC] void SelectHero(NetworkViewID viewId) {
		GameObject playerCharacter = NetworkView.Find(viewId).gameObject;
		GameObject cameraContainer = GameObject.Find("Camera");
		Moba_Camera cameraController = cameraContainer.GetComponent<Moba_Camera>();
		cameraController.settings.lockTargetTransform = playerCharacter.transform;
		playing = true;
	}

}