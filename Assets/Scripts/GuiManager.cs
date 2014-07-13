using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	private string serverIP = "127.0.0.1";

	void OnGUI() {


		if (!Network.isClient && !Network.isServer) {
			#if INCLUDE_SERVER
			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 30, 100, 20), "Start Server")) {
				Server.StartServer();
			}
			#endif

			serverIP = GUI.TextField(new Rect(
				Screen.width/2 - 50,
				Screen.height/2 + 10,
				100, 20), serverIP
			);

			if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 40, 100, 20), "Connect")) {
				Client.StartClient(serverIP);
			}
		}
	}
}