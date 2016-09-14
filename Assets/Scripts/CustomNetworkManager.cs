using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager {

	public Transform hostCentre;
	public Transform camLeft;
	public Transform camCentre;
	public Transform camRight;

	public new Transform GetStartPosition(){
		string n = "";
		return getTarget (numPlayers, out n);
	}

	private Transform getTarget( int c, out string text ) {

		text = "";
		if (c == 0) {
			text = "HOST";
			return hostCentre;
		} else if (c == 1) {
			text = "Client CENTRE";
			return camCentre;
		} else if (c == 2) {
			text = "Client LEFT";
			return camLeft;
		} else {
			text = "Client RIGHT";
			return camRight;
		}
	}



	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{

		bool isHost = numPlayers == 0;
		bool irVisible = numPlayers != 0;

		Transform spawnTransform = GetStartPosition();
	
		GameObject player = (GameObject)GameObject.Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
		ClientCamera client = (ClientCamera)player.GetComponent ("ClientCamera");

		client.irVisible = irVisible;

		string clientText = "HOST";

		if (isHost) {
			player.transform.parent = hostCentre;
			//client.target = getTarget (numPlayers);
		} else {
			client.target = getTarget (numPlayers, out clientText);
		}
			
		client.tooltip = clientText + (irVisible ? " (IR)" : "");

		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	
		client.IR (irVisible);

	}
}
