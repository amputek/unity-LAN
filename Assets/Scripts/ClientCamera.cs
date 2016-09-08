using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientCamera : NetworkBehaviour {

	public Camera myCamera;
	public float speed = 0.2f;

	[SyncVar]
	public Transform target;


	void Start(){

		if (isLocalPlayer) {
			
		} else {
			
			//In the Client's Scene, cameras that don't belong to the Player are disabled
			myCamera.enabled = false;
		}

	}




	void Update(){

		if (!isLocalPlayer) {
			return;
		}

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, step * 5.0f);
	}

}
