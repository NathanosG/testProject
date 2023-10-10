using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigIcon : MonoBehaviour
{
    public GameObject car;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, car.transform.localEulerAngles.y+offset, transform.localEulerAngles.z);
    }
}
