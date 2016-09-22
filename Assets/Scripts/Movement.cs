using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = 10;
    public Light spotlightIR;

	// Use this for initialization
	void Start () {
        //print("yo im a player");
        //moveSpeed = 50f;
	}
	
	// Update is called once per frame
	void Update () {
        //print(Input.GetAxis("Horizontal"));

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        //transform.Translate(0f, moveSpeed/2 * Input.GetAxis("Jump") * Time.deltaTime, 0f );
        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    transform.Translate(0f, -moveSpeed / 2 * Time.deltaTime, 0f);
        //}

        if (Input.GetKeyDown("i"))
        {
            spotlightIR.intensity = 2f;
        }

        if (Input.GetKeyDown("o"))
        {
            spotlightIR.intensity = 0f;
        }

    }
}
