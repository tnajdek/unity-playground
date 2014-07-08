using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour {
	#if INCLUDE_SERVER
	private int playerCount = 0;
	private NetworkPlayer[] players;
	private Object playerPrefab;

	void Start() {
		playerPrefab = Resources.Load("robot-player"); //GameObject.Find("robot-player");
	}

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
	[RPC] void SpawnPlayer(string username, NetworkMessageInfo info) {
		Network.Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
	}
	#endif
}