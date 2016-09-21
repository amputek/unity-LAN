using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class ClientCamera : NetworkBehaviour {

	public float posSpeed = 3.0f;
	public float rotSpeed = 15.0f;

	[SyncVar]
	public Transform target;

	[SyncVar]
	public bool irVisible = true;

	[SyncVar]
	public string tooltip = "Default";

	private Text text;


	void Start(){


		if (!isLocalPlayer) {
			//In the Client's Scene, cameras that don't belong to this specific Player are disabled
			//myCamera.enabled = false;
			transform.Find ("Camera").GetComponent<Camera> ().enabled = false;
		} else {

			IR(irVisible);
			GameObject t = transform.Find ("Camera/Canvas/Text").gameObject;
			Text text = t.GetComponent<Text>();

			text.text = tooltip;
		}
			
		GameObject[] testObjects = GameObject.FindGameObjectsWithTag ("Test");
		foreach (GameObject obj in testObjects) {
			obj.SetActive (false);
		}

	}

	/// <summary>
	/// Hide objects with IR tag, for this client
	/// </summary>
	public void IR( bool irVisible ){


		if (!isLocalPlayer)
			return;

		//if client can see IR objects, set these objects active for this client.
		//otherwise, turn em off


		GameObject cam = transform.Find("Camera").gameObject;
		ColorCorrectionCurves colorCorrection = cam.GetComponent<ColorCorrectionCurves>();
		BloomOptimized bloom = cam.GetComponent<BloomOptimized>();


		//if ir capable, ambient light is FULL, IR objects are VISIBLE, and bloom/desaturation are ACTIVE
		//otherwise, it's night time

		RenderSettings.ambientIntensity    = irVisible ? 1.0f : 0.3f;
		RenderSettings.reflectionIntensity = irVisible ? 0.5f : 0.2f;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("IR")) {
			obj.SetActive (irVisible);
		}
		bloom.enabled = irVisible;
		colorCorrection.enabled = irVisible;


			
	}

	void Update(){

		if (!isLocalPlayer)
			return;
	
		if (!target)
			return;
		
	//	transform.position = Vector3.MoveTowards(transform.position, target.position, posSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp (transform.position, target.position, posSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotSpeed * Time.deltaTime);

	}

}
