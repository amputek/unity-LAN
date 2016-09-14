using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        //print("yo im a player");
        moveSpeed = 50f;
	}
	
	// Update is called once per frame
	void Update () {
        //print(Input.GetAxis("Horizontal"));

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }
}
