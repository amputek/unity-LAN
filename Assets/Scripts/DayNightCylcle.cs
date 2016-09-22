using UnityEngine;
using System.Collections;

public class DayNightCylcle : MonoBehaviour {

    public Light light;
    public Vector3 targetAngle = new Vector3(60f, -30f, 0f);
    public float rotateSpeed = 1f;
    private Vector3 currentAngle;
    private Vector3 newAngle;

    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
        currentAngle = transform.eulerAngles;
        rotateSpeed = 1f;
        newAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, rotateSpeed * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, rotateSpeed * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, rotateSpeed * Time.deltaTime));
        transform.eulerAngles = newAngle;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.P))
        {
            transform.Rotate(10f * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(-10f * Time.deltaTime, 0, 0);
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
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 1f, Time.deltaTime * 0.3f);
        }
    }
}
