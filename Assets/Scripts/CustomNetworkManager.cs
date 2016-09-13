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
		return getTarget (numPlayers);
	}

	private Transform getTarget( int c ) {
		if (c == 0) {
			return hostCentre;
		} else if (c == 1) {
			return camCentre;
		} else if (c == 2) {
			return camCentre;
		} else {
			return camRight;
		}
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{

		bool isHost = numPlayers == 0;
		bool irVisible = numPlayers == 1;


	
		Transform spawnTransform = GetStartPosition();
	
		GameObject player = (GameObject)GameObject.Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
		ClientCamera client = (ClientCamera)player.GetComponent ("ClientCamera");



		client.irVisible = irVisible;

		if (numPlayers == 0)
			client.tooltip = "Host";
		if (numPlayers == 1)
			client.tooltip = "Client CENTRE";
		if (numPlayers == 2)
			client.tooltip = "Client CENTRE";
		if (numPlayers == 3)
			client.tooltip = "Client RIGHT";

		if(irVisible)
			client.tooltip = client.tooltip + " (IR)";


		if (isHost) {
			player.transform.parent = hostCentre;
			//client.target = getTarget (numPlayers);
		} else {
			client.target = getTarget (numPlayers);
		}
			
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	

		client.IR (irVisible);

	}
}
