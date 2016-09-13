using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

[NetworkSettings(channel=0,sendInterval=0.05f)]
public class ClientCamera : NetworkBehaviour {

	public Camera myCamera;
	public float posSpeed = 3.0f;
	public float rotSpeed = 15.0f;

	[SyncVar]
	public Transform target;

	[SyncVar]
	public bool irVisible = true;

	[SyncVar]
	public string tooltip = "Default";

	public Text text;

	public ColorCorrectionCurves colorCorrection;
	public BloomOptimized bloom;


	void Start(){
		if (!isLocalPlayer) {
			//In the Client's Scene, cameras that don't belong to this specific Player are disabled
			myCamera.enabled = false;
		} else {
			IR(irVisible);
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

		GameObject[] irVisibleObjects = GameObject.FindGameObjectsWithTag ("IR");

	
		//if ir capable, ambient light is FULL, IR objects are VISIBLE, and bloom/desaturation are ACTIVE
		//otherwise, it's night time
		if (irVisible) {
			RenderSettings.ambientIntensity = 1.5f;
			RenderSettings.reflectionIntensity = 1.0f;
			foreach (GameObject obj in irVisibleObjects) {
				obj.SetActive (true);
			}
			bloom.enabled = true;
			colorCorrection.enabled = true;
		} else {
			RenderSettings.ambientIntensity = 0.2f;
			RenderSettings.reflectionIntensity = 0.2f;
			foreach (GameObject obj in irVisibleObjects) {
				obj.SetActive (false);
			}
			bloom.enabled = false;
			colorCorrection.enabled = false;
		}
			
	}

	void Update(){

		if (!isLocalPlayer)
			return;
	
		if (!target)
			return;
		
	//	transform.position = Vector3.MoveTowards(transform.position, target.position, posSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp (transform.position, target.position, posSpeed * Time.deltaTime);

	//	if( Quaternion.Angle( transform.rotation, target.rotation) > 0.1 )
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotSpeed * Time.deltaTime);

	}

}
