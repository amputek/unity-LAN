using UnityEngine;
using System.Collections;

public class PlayerOriginRotation : MonoBehaviour {
    public float rotateSpeed = 5f;

	// Use this for initialization
	void Start () {
        rotateSpeed = 5f;
	
	}
	
	// Update is called once per frame
	void Update () {
        // put general rotation here
        transform.Rotate(0, -rotateSpeed*Time.deltaTime, 0);
    }
}
