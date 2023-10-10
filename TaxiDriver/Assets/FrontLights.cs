using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontLights : MonoBehaviour
{
    public GameObject dashboardLight;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashboardLight.GetComponent<Lights>().on)
        {
            light.intensity = 1.35f;
        }
        else
        {
            light.intensity = 0.0f;
        }
    }
}
