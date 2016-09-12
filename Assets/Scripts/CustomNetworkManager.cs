using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	public Transform hostCentre;
	public Transform camLeft;
	public Transform camRight;

	public Transform GetStartPosition(){
		return getTarget (numPlayers);
	}

	private Transform getTarget( int c ) {
		if (c == 0) {
			return hostCentre;
		} else if( c == 1 ){
			return camLeft;
		} else {
			return camRight;
		}

	}
		
		

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{

		int c = numPlayers;
		Transform spawn = GetStartPosition();

		var player = (GameObject)GameObject.Instantiate(playerPrefab, spawn.position, spawn.rotation);


		ClientCamera cc = (ClientCamera)player.GetComponent ("ClientCamera");
		cc.target = getTarget (c);

		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);


		//player.transform.position = new Vector3 (playerCount * 2.0f, 0.0f, 0.0f);

	}
}
