using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Server : MonoBehaviour {
	#if INCLUDE_SERVER
	private int playerCount = 0;
	private Dictionary<NetworkPlayer, GameObject> players;
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
		GameObject mehe = Network.Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, 0) as GameObject;
		Navigation nav = mehe.GetComponent<Navigation>();

	}
	[RPC] void WalkTo(Vector3 whereTo) {
		Debug.Log(whereTo);
	}
	#endif
}