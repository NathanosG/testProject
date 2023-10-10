using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRoad : MonoBehaviour
{   
    public GameObject car;

    private float timer;
    private bool spawned=false;
    private bool hit=false;
    private bool fallen=false;

    private Vector3 originalPos;
    private Quaternion originalRot;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(8,20);
        originalPos = transform.localPosition;
        originalRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0 && !spawned && !hit && !fallen)
        {
            SpawnPedestrian();
        }
        else if (!spawned && !hit && !fallen)
        {
            timer -= Time.deltaTime;
        }
        else if (spawned && !hit && !fallen)
        {
            if (transform.localPosition.z < -6.5f)
            {
                spawned = false;
                transform.localPosition = new Vector3(transform.localPosition.x, -10f, transform.localPosition.z);
                timer = Random.Range(8,20);
            }
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z-Time.deltaTime*2f);
        }
        else if (hit)
        {
            
            /*if (the absolute value of z rotation OR absolute value of x rotation is > 80...)*/
            if ((Mathf.Abs(transform.localEulerAngles.z) > 80 && Mathf.Abs(transform.localEulerAngles.z) < 360-80) || (Mathf.Abs(transform.localEulerAngles.x) > 80 && Mathf.Abs(transform.localEulerAngles.x) < 360-80))
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<Collider>().enabled = false;
                fallen = true;
                hit = false;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else if (fallen)
        {
            if (Vector3.Distance(transform.position, car.transform.position) > 50f)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().useGravity = false;
                fallen = false;
                timer = Random.Range(8,20);
                transform.rotation = originalRot;
                transform.position = originalPos;
                GetComponent<Collider>().enabled = true;
            }
        }
    }

    void SpawnPedestrian()
    {
        spawned = true;
        if (transform.gameObject.name == "man")
        {
            transform.localPosition = new Vector3(-0.65f, 0.3f, 6f);
        }
        else if (transform.gameObject.name == "woman")
        {
            transform.localPosition = new Vector3(0.65f, 0.4f, 6f);
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "floor")
        {
            GetComponent<Rigidbody>().useGravity = true;
            hit = true;
            spawned = false;
            timer = 1f;
        }
    }
}
