using UnityEngine;
using System.Collections;

public class MoonCylcle : MonoBehaviour {
    public float distance = -10000.0f;
    public float scale = 500.0f;
	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, distance);
        transform.localScale = new Vector3(scale, scale, scale);
	}

	void Update () {
        
    }
}
