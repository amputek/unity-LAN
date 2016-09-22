using UnityEngine;
using System.Collections;

public class ChopperMovement : MonoBehaviour {
    public float rotateSpeed = 10f;

	// Use this for initialization
	void Start () {
        rotateSpeed = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {
        // put general rotation here
        transform.Rotate(0, -rotateSpeed*Time.deltaTime, 0);
    }
}
