using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EmptyClient : NetworkBehaviour {


	void Start(){

		if (isLocalPlayer) {
			transform.parent = GameObject.Find ("Player").transform;
			transform.localPosition = Vector3.zero;
			GameObject.Find ("Camera 2").SetActive (false);
		} else {


		}
	}

}
