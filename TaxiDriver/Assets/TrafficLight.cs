using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField]
    GameObject[] red;
    [SerializeField]
    GameObject[] amber;
    [SerializeField]
    GameObject[] green;

    private int greenIndex = 0;

    private float timer = 0;

    private bool changing=false;
    private bool changing2=false;
    private bool changing3=false;

    // Start is called before the first frame update
    void Start()
    {
        red[greenIndex].GetComponent<Light>().intensity = 0f;
        green[greenIndex].GetComponent<Light>().intensity = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {


        if (timer > 6 && !changing && !changing2 && !changing3)
        {
            changing = true;
            timer = 0;
            amber[greenIndex].GetComponent<Light>().intensity = 1.5f;
            green[greenIndex].GetComponent<Light>().intensity = 0f;

        }
        else if (timer > 2 && changing)
        {
            timer = 0;
            changing = false;
            changing2 = true;
            red[greenIndex].GetComponent<Light>().intensity = 1.5f;
            amber[greenIndex].GetComponent<Light>().intensity = 0f;
            if (greenIndex+1 < 4)
            {
                greenIndex += 1;
                //red[greenIndex].GetComponent<Light>().intensity = 0f;
                //green[greenIndex].GetComponent<Light>().intensity = 1.5f;
            }
            else
            {
                greenIndex = 0;
                //red[greenIndex].GetComponent<Light>().intensity = 0f;
                //green[greenIndex].GetComponent<Light>().intensity = 1.5f;
            }
        }
        else if (timer > 2 && changing2)
        {
            timer = 0;
            changing3 = true;
            changing2 = false;
            amber[greenIndex].GetComponent<Light>().intensity = 1.5f;
        }
        else if (timer > 2 && changing3)
        {
            timer = 0;
            changing3 = false;
            amber[greenIndex].GetComponent<Light>().intensity = 0f;
            green[greenIndex].GetComponent<Light>().intensity = 1.5f;
            red[greenIndex].GetComponent<Light>().intensity = 0f;
        }


        timer += Time.deltaTime;
    }
}
