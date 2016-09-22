using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

    public float smooth;
    private Transform follow;
    private Vector3 targetPosition;
    public GameObject viewPosition;


	// Use this for initialization
	void Start () {
        //follow = GameObject.FindWithTag("Player").transform;
        follow = viewPosition.transform;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, follow.position, Time.deltaTime * smooth);
    }
}
