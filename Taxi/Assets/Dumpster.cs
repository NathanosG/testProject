using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;
    private GameObject car;
    private WheelController movement;

    private Vector3 targetRot = new Vector3(0,0,0);
    private Vector3 currentRot = new Vector3(0,0,0);

    private float speed=0;

    private bool hit=false;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        car = playerScript.cars[playerScript.currentCar];

        movement = car.GetComponent<WheelController>();
        transform.GetChild(1).localEulerAngles = currentRot;
    }

    // Update is called once per frame
    void Update()
    {
        car = playerScript.cars[playerScript.currentCar];
        movement = car.GetComponent<WheelController>();

        currentRot = Vector3.Lerp(currentRot, targetRot, Time.deltaTime * 20);
        transform.GetChild(1).localEulerAngles = currentRot;
        if (Mathf.Round(currentRot.z) == Mathf.Round(targetRot.z))
        {
            targetRot = new Vector3(0,-90,0);
            hit = false;
        }         


    }

    void OnCollisionEnter(Collision other)
    {
        if (/*other.gameObject.name == "Car" &&*/ !hit)
        {
            speed = movement.speed;
            targetRot = new Vector3(-35*speed,-90,0);
            hit = true;
        }
    }
}
