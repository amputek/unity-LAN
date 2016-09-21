using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomNetworkHUD : NetworkManagerHUD {


	void OnGUI()
	{

		if (!showGUI)
			return;

		int xpos = 10;
		int ypos = 10;
		int buttonWidth = 200;
		int buttonHeight = 20;
		int spacing = 4;


		if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null) {



			manager.networkAddress = GUI.TextField (new Rect (xpos, ypos, buttonWidth, buttonHeight), manager.networkAddress);
			ypos += buttonHeight + spacing;
			if (GUI.Button (new Rect (xpos, ypos, buttonWidth/2, buttonHeight), "Join as Host")) {
				manager.StartHost ();
			}
			xpos += buttonWidth/2 + spacing;
			if (GUI.Button (new Rect (xpos, ypos, buttonWidth/2, buttonHeight), "Join as Client")) {
				manager.StartClient ();
			}


		} else {
		
			if (NetworkServer.active) {
				GUI.Label (new Rect (xpos, ypos, 300, buttonHeight), "Server:" + manager.networkPort);
				ypos += buttonHeight;
				GUI.Label (new Rect (xpos, ypos, 300, buttonHeight), "Client: " + manager.networkAddress + ":" + manager.networkPort);
				ypos += buttonHeight;

			}

			if (NetworkServer.active || NetworkClient.active)
			{
				if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Exit Server"))
				{
					manager.StopHost();
				}
			}
		}

	}

}
