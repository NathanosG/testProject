using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrolStop : MonoBehaviour
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
    private float cost=0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        carScript = car.GetComponent<WheelController>();
        status = car.GetComponent<Status>();
        matArray = rend.materials;
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
            timer = 1;
            complete = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(coll.bounds.Contains(other.bounds.min) && coll.bounds.Contains(other.bounds.max) && Mathf.Round(carScript.speed) == 0f && status.balance - (100 - status.petrol) / 2 > 0)
        {
            if (!complete)
            {
                matArray[1] = material2;
                rend.materials = matArray;

                if (status.petrol < status.maxPetrol)
                {
                    status.petrol += Time.deltaTime*2;

                    cost += Time.deltaTime;
                }
                else
                {
                    status.petrol = status.maxPetrol;
                    complete = true;

                    status.balance -= cost;
                    cost = 0;
                }
            }
            else
            {
                matArray[1] = material1;
                rend.materials = matArray;
            }



        }
        else if (coll.bounds.Contains(other.bounds.min) && coll.bounds.Contains(other.bounds.max) && Mathf.Round(carScript.speed) == 0f)
        {
            //not enough money
            matArray[1] = material3;
            rend.materials = matArray;
        }
        else
        {
            matArray[1] = material1;
            rend.materials = matArray;
            status.balance -= cost;
            cost = 0;
        }
    }
}
