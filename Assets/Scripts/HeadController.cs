using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HeadController : NetworkBehaviour {

	[SyncVar]
	private float xRot = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//var look = Input.GetAxis ("LookVertical") * Time.deltaTime * -30.0f;
		//transform.Rotate (look, 0, 0);

		xRot += Input.GetAxis("LookVertical") * Time.deltaTime * -30.0f;
		xRot = Mathf.Clamp (xRot, -30, 30);
	//	transform.localEulerAngles = new Vector3 (xRot, transform.localEulerAngles.y, transform.localEulerAngles.z);
		transform.localRotation = Quaternion.Euler(xRot,0,0);
	}
}
