using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingBarrier : MonoBehaviour
{
    private float timer=0.5f;
    public GameObject car;
    private WheelController movement;
    private bool canClose=false;

    private Vector3 targetRot = new Vector3(0,0,0);
    private Vector3 currentRot = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        movement = car.GetComponent<WheelController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRot = Vector3.Lerp(currentRot, targetRot, Time.deltaTime);
        transform.GetChild(1).localEulerAngles = currentRot;
        if (Mathf.Round(currentRot.x) == Mathf.Round(targetRot.x) && canClose)
        {
            targetRot = new Vector3(0,0,0);
            canClose = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Car" && Mathf.Round(movement.speed) == 0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            targetRot = new Vector3(40,0,0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            timer = 0.5f;
            targetRot = new Vector3(0,0,0);
            canClose = true;
        }
    }
}
