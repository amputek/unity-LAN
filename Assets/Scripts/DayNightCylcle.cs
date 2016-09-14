using UnityEngine;
using System.Collections;

public class DayNightCylcle : MonoBehaviour {

    public Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.5f, 0, 0);
        LightIntensity();

    }

    void LightIntensity ()
    {
        // Use Lerp
        // Figure out why sky turns blue!!!
        if (transform.rotation.eulerAngles.x > 210 & transform.rotation.eulerAngles.x < 320)
        {
            light.intensity = 0.1f;
        }
        else
        {
            light.intensity = 1.0f;
        }
    }
}
