using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheel : MonoBehaviour
{
    private int state=0;
    private float initY;
    // Start is called before the first frame update
    void Start()
    {
        initY = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && Input.GetKey("d"))
        {
            state = 0;
        }
        else if (Input.GetKey("a"))
        {
            state = 1;
        }
        else if (Input.GetKey("d"))
        {
            state = 2;
        }
        else
        {
            state = 0;
        }

        switch (state)
        {
            case 0:
                Center();
                break;
            case 1:
                Left();
                break;
            case 2:
                Right();
                break;

        }

        if (Input.GetKey("w"))
        {
            transform.localEulerAngles += new Vector3(0,0,0.5f);
        }
        else if (Input.GetKey("s"))
        {
            transform.localEulerAngles += new Vector3(0,0,-0.5f);
        }
    }

    void Center()
    {
        transform.localEulerAngles = new Vector3(0,initY,transform.localEulerAngles.z);
    }

    void Left()
    {
        transform.localEulerAngles = new Vector3(0,initY-20,transform.localEulerAngles.z);
    }

    void Right()
    {
        transform.localEulerAngles = new Vector3(0,initY+20,transform.localEulerAngles.z);
    }
}
