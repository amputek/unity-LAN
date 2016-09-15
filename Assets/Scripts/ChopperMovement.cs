using UnityEngine;
using System.Collections;

public class ChopperMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // put general rotation here
        transform.Rotate(0, -0.1f, 0);
    }
}
