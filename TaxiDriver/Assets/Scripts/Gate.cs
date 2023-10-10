using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject car;
    private bool fallen=false;
    private Vector3 originalPos;
    private Quaternion originalRot;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (fallen)
        {
            if(!CheckRaycast() && Vector3.Distance(transform.position, car.transform.position) > 50f)
            {
                transform.position = originalPos;
                transform.rotation = originalRot;
                fallen = false;
            }
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name != "floor")
        {
            fallen = true;
        }
    }
    
    bool CheckRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, car.transform.position-transform.position, out hit, Vector3.Distance(transform.position, car.transform.position)))
        {
            if (hit.transform == car.transform)
            {
                return true;
            }
        }
        return false;
    }
}
