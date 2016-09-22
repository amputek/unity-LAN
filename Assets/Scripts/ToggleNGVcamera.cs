using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ToggleNGVcamera : MonoBehaviour {
    public Camera thisCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            thisCamera.GetComponent<Grayscale>().enabled = !thisCamera.GetComponent<Grayscale>().enabled;
        }
        
    }
}
