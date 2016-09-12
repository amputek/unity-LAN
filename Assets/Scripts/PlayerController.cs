using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{

	public CharacterController controller;

	void Start(){

	}

	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		//transform.Rotate(0, x, 0);
	//	transform.Translate(x, 0, z);

		Vector3 mvt = new Vector3 (x, 0, z);

		mvt = transform.TransformDirection(mvt);

		controller.Move (mvt);

	}




}
