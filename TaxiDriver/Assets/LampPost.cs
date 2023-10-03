using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPost : MonoBehaviour
{
    public GameObject car;
    private bool fallen=false;
    private Vector3 originalPos;
    private Quaternion originalRot;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (fallen)
        {
            if(!CheckRaycast() && Vector3.Distance(transform.position, car.transform.position) > 50f)
            {
                for (int i = 0; i < transform.childCount; i ++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
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
            for (int i = 0; i < transform.childCount; i ++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
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
