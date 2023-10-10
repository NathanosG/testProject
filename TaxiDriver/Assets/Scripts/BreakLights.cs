using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLights : MonoBehaviour
{
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey("s") || Input.GetKey(KeyCode.Space) && Input.GetKey("s"))
        {
            light.color = Color.red;
            light.intensity = 3;
        }
        else if (Input.GetKey("s"))
        {
            light.color = Color.yellow;
            light.intensity = 3;
        }
        else
        {
            light.color = Color.red;
            light.intensity = 0.5f;
        }
    }
}
