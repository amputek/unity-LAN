using UnityEngine;
using System.Collections;

public class ToggleNightMode : MonoBehaviour {

    public Light thisLight;
    //public bool isEnabled;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            thisLight.enabled = !thisLight.enabled;
        }


    }
}
