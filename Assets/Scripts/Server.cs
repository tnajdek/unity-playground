#if INCLUDE_SERVER
using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour {
	private int playerCount = 0;

	public static void StartServer() {
		//Network.incomingPassword = "";
		//bool useNat = !Network.HavePublicAddress();
		Network.InitializeServer(32, 25000, false);
		Debug.Log("Server is starting");
	}

	void OnServerInitialized() {
		Debug.Log("Server Initializied");
	}

	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
	}
}
#endif