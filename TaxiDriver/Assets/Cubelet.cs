using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubelet : MonoBehaviour
{
    public GameObject car;
    private bool fallen=false;
    private Vector3 originalPos;
    private Quaternion originalRot;
    private Collider col;
    private Renderer rend;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;  
        col = GetComponent<Collider>();  
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fallen)
        {
            if(Vector3.Distance(transform.position, car.transform.position) > 50f)
            {
                transform.position = originalPos;
                transform.rotation = originalRot;
                col.enabled = true;
                rend.enabled = true;
                fallen = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Car")
        {
            //rb.constraints = RigidbodyConstraints.None;
            rend.enabled = false;
            col.enabled = false;
            fallen = true;
        }


    }
}
