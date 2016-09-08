﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientCamera : NetworkBehaviour {

	public Camera myCamera;

	void Start(){

		if (isLocalPlayer) {
			transform.parent = GameObject.Find ("Player").transform;
			transform.localPosition = Vector3.zero;
		} else {
			myCamera.enabled = false;
		}

	}




	// Update is called once per frame
	void Update () {
	
	}


}
