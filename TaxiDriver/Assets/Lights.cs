using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lights : MonoBehaviour
{
    public bool on=false;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            on = !on;
        }
        if (on)
        {
            img.color = new Color(255,255,255);
        }
        else
        {
            img.color = new Color(0,0,0);
        }
    }
}
