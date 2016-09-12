using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[NetworkSettings(channel=0,sendInterval=0.02f)]
public class ClientCamera : NetworkBehaviour {

	public Camera myCamera;
	public float posSpeed = 3.0f;
	public float rotSpeed = 15.0f;

	[SyncVar]
	public Transform target;

	void Start(){
		if (!isLocalPlayer) {
			//In the Client's Scene, cameras that don't belong to this specific Player are disabled
			myCamera.enabled = false;
		}
	}
		
	public void setText( string s ){
		Text t = GetComponentInChildren<Text> ();
		t.text = s;
	}
		
	void Update(){

		if (!isLocalPlayer)
			return;
	
		if (!target)
			return;
		
		transform.position = Vector3.MoveTowards(transform.position, target.position, posSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotSpeed * Time.deltaTime);

	}

}
