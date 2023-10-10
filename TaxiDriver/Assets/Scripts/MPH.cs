using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MPH : MonoBehaviour
{
    public GameObject car;
    public TextMeshProUGUI text;
    private WheelController carScript;
    // Start is called before the first frame update
    void Start()
    {
        carScript = car.GetComponent<WheelController>();
        //text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        text.SetText((Mathf.Round(carScript.speed*4)).ToString()+"mph");
    }
}
