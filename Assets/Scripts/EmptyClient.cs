using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EmptyClient : NetworkBehaviour {

	private Transform target;

	public float speed = 0.1f;

	void Start(){

		if (isLocalPlayer) {
		//	transform.parent = GameObject.Find ("Player").transform;
		//	transform.localPosition = Vector3.zero;
			target = GameObject.Find ("Player").transform;
			GameObject.Find ("Camera 2").SetActive (false);
		} else {


		}
	}

	void Update(){

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
