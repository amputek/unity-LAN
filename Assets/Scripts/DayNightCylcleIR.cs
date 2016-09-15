using UnityEngine;
using System.Collections;

public class DayNightCylcleIR : MonoBehaviour {

    public Light light;

    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.P))
        {
            transform.Rotate(1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(-1f, 0, 0);
        }

        LightIntensity();

    }

    void LightIntensity ()
    {
        // Use Lerp
        if (transform.rotation.eulerAngles.x > 200 & transform.rotation.eulerAngles.x < 340)
        {
            light.intensity = Mathf.Lerp(light.intensity, 0.05f, Time.deltaTime * 0.3f);
        }
        if (transform.rotation.eulerAngles.x > 200 & transform.rotation.eulerAngles.x > 340)
        {
            light.intensity = Mathf.Lerp(light.intensity, 6f, Time.deltaTime * 0.3f);
        }
    }
}
