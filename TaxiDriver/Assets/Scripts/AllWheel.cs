using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWheel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.localEulerAngles += new Vector3(0,0,0.5f);
        }
        else if (Input.GetKey("s"))
        {
            transform.localEulerAngles += new Vector3(0,0,-0.5f);
        }
    }
}
