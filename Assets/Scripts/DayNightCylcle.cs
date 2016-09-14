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
        if (transform.rotation.eulerAngles.x > 200 & transform.rotation.eulerAngles.x < 340)
        {
            light.intensity = Mathf.Lerp(light.intensity, 0.05f, Time.deltaTime * 0.5f);
        }
        if (transform.rotation.eulerAngles.x > 200 & transform.rotation.eulerAngles.x > 340)
        {
            light.intensity = Mathf.Lerp(light.intensity, 2f, Time.deltaTime * 0.5f);
        }
    }
}
