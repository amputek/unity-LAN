using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientCamera : NetworkBehaviour {

	public Camera myCamera;
	public Text myTextBox;

	void Start(){



		if (isLocalPlayer) {
			transform.parent = GameObject.Find ("Player").transform;
			transform.localPosition = Vector3.zero;
			transform.Rotate (0, Random.Range (-30, 30), 0);
			Debug.Log ("Controller ID: " + playerControllerId);
			Debug.Log (myTextBox);
			myTextBox.text = "Your ID: " + playerControllerId;

		} else {
			myCamera.enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
