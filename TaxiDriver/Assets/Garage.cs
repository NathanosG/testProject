using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    public Collider coll;
    public GameObject car;
    private MeshRenderer rend;
    private WheelController carScript;
    private Status status;
    private bool complete=false;
    public GameObject carLift;
    private CarLifter carLifter;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        carScript = car.GetComponent<WheelController>();
        status = car.GetComponent<Status>();
        carLifter = carLift.GetComponent<CarLifter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.enabled == false)
        {
            InGarage();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            if (coll.bounds.Contains(other.bounds.min) && coll.bounds.Contains(other.bounds.max) && (Mathf.Round(carScript.speed) == 0f || carScript.canMove == false) && !complete)
            {
                car.GetComponent<Rigidbody>().useGravity = false;
                car.transform.position = new Vector3(carLift.transform.position.x, carLift.transform.position.y+1.1f, carLift.transform.position.z);
                car.transform.localEulerAngles = new Vector3(0, -90, 0);
                if (carScript.canMove == true)
                {
                    carLifter.Lift();
                }
                rend.enabled = false;
                carScript.canMove = false;
            }
            else
            {
                rend.enabled = true;
                carScript.canMove = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            complete = false;
        }

    }

    void InGarage()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !rend.enabled && status.stats.unlocked)
        {
            car.GetComponent<Rigidbody>().useGravity = true;
            carLifter.Lift();
            complete = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !rend.enabled && status.balance >= status.stats.price)
        {
            status.stats.unlocked = true;
            status.balance -= status.stats.price;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && status.activeInd+1 < status.ChildCount())
        {
            status.ChangeCar(status.activeInd+1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && status.activeInd-1 >= 0)
        {
            status.ChangeCar(status.activeInd-1);
        }
    }
}
