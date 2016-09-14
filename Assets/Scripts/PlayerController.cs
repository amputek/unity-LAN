using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{

	//public CharacterController controller;

	public float speed = 2.0f;

	void Start(){

	}

	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		Vector3 mvt = new Vector3 (x, 0, z);

		//mvt = transform.TransformDirection(mvt);
		//controller.Move (mvt);

		transform.Translate (mvt);

	}




}
