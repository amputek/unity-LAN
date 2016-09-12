using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager {

	public Transform hostCentre;
	public Transform camLeft;
	public Transform camCentre;
	public Transform camRight;

	public GameObject hostPrefab;

	public new Transform GetStartPosition(){
		return getTarget (numPlayers);
	}

	private Transform getTarget( int c ) {
		if (c == 0) {
			return hostCentre;
		} else if (c == 1) {
			return camLeft;
		} else if (c == 2) {
			return camCentre;
		} else {
			return camRight;
		}

	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{

		int c = numPlayers;
	
		Transform spawnTransform = GetStartPosition();
	
		GameObject player;

		if (c == 0) {
			player = (GameObject)GameObject.Instantiate(hostPrefab, spawnTransform.position, spawnTransform.rotation);
			player.transform.parent = hostCentre;
		} else {
			player = (GameObject)GameObject.Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
			ClientCamera cc = (ClientCamera)player.GetComponent ("ClientCamera");
			cc.target = getTarget (c);
		}
			
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	
	}
}
