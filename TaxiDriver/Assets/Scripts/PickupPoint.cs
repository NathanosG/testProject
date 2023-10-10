using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoint : MonoBehaviour
{
    public Collider coll;
    public GameObject car;
    public Material material1;
    public Material material2;
    public Material material3;
    private MeshRenderer rend;
    private WheelController carScript;
    private bool complete;
    private float timer=1;
    private Material[] matArray;
    private Status status;
    public GameObject pickup;
    public GameObject dropoff;
    private PickupPoints pickupPoints;
    private PickupPoints dropoffPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        carScript = car.GetComponent<WheelController>();
        status = car.GetComponent<Status>();
        matArray = rend.materials;

        pickupPoints = pickup.GetComponent<PickupPoints>();
        dropoffPoints = dropoff.GetComponent<PickupPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (complete)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            transform.gameObject.SetActive(false);
            if (status.status == 0)
            {
                status.status = 1;
                dropoffPoints.New();
            }
            else if (status.status == 1)
            {
                status.status = 0;
                status.score += 1;
                status.balance += status.stats.moneyInc;
                pickupPoints.New();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            if(coll.bounds.Contains(other.bounds.min) && coll.bounds.Contains(other.bounds.max) && Mathf.Round(carScript.speed) == 0f)
            {
                matArray[1] = material3;
                rend.materials = matArray;
                //rend.material = material3;
                complete = true;
            }
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            matArray[1] = material2;
            rend.materials = matArray;
            //rend.material = material2;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            matArray[1] = material1;
            rend.materials = matArray;
            //rend.material = material1;
        }
    }
}
