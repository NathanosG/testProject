using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int status = 0;
    public int score = 0;
    public float petrol;
    public float maxPetrol;
    public float balance = 0;
    public GameObject pickup;
    public int activeInd=0;
    //private Movement movement;
    private WheelController movement;

    private PickupPoints pickupPoints;

    public Stats stats;
    
    void Start()
    {
        movement = transform.gameObject.GetComponent<WheelController>();
        pickupPoints = pickup.GetComponent<PickupPoints>();
        pickupPoints.New();
        stats = transform.GetChild(0).GetChild(activeInd).GetComponent<Stats>();
        maxPetrol = stats.maxPetrol;
        petrol = stats.curPetrol;
    }

    // Update is called once per frame
    void Update()
    {
        petrol -= Time.deltaTime*movement.speed/50;
        if (petrol < 0)
        {
            petrol = 0;
            movement.canMove = false;
        }
            /*if (movement.speed > 0 && petrol != 0)
            {
                if (petrol < 0)
                {
                    petrol = 0;
                }
                else
                {
                    petrol -= Time.deltaTime*movement.speed/50;
                }
            }*/
    }

    public void ChangeCar(int index)
    {
        stats.curPetrol = petrol;
        transform.GetChild(0).GetChild(activeInd).gameObject.SetActive(false);
        activeInd = index;
        transform.GetChild(0).GetChild(activeInd).gameObject.SetActive(true);
        for (int i = 0; i < transform.GetChild(0).GetChild(activeInd).childCount; i++)
        {
            transform.GetChild(0).GetChild(activeInd).GetChild(i).gameObject.SetActive(true);
        }
        
        stats = transform.GetChild(0).GetChild(activeInd).GetComponent<Stats>();

        
        movement.frontRight = transform.GetChild(0).GetChild(activeInd).Find("WheelColliders").GetChild(0).GetComponent<WheelCollider>();
        movement.frontLeft = transform.GetChild(0).GetChild(activeInd).Find("WheelColliders").GetChild(1).GetComponent<WheelCollider>();
        movement.backRight = transform.GetChild(0).GetChild(activeInd).Find("WheelColliders").GetChild(2).GetComponent<WheelCollider>();
        movement.backLeft = transform.GetChild(0).GetChild(activeInd).Find("WheelColliders").GetChild(3).GetComponent<WheelCollider>();

        movement.frontRightTransform = transform.GetChild(0).GetChild(activeInd).Find("WheelMeshes").GetChild(2);
        movement.frontLeftTransform = transform.GetChild(0).GetChild(activeInd).Find("WheelMeshes").GetChild(0);
        movement.backRightTransform = transform.GetChild(0).GetChild(activeInd).Find("WheelMeshes").GetChild(3);
        movement.backLeftTransform = transform.GetChild(0).GetChild(activeInd).Find("WheelMeshes").GetChild(1);
        
        movement.acceleration = stats.acceleration;
        movement.breakingForce = stats.breakingForce;
        movement.maxTurnAngle = stats.maxTurnAngle;
        
        movement.maxSpeed = stats.maxSpeed;

        movement.rb.drag = stats.drag;

        petrol = stats.curPetrol;
        maxPetrol = stats.maxPetrol;



    }

    public int ChildCount()
    {
        return transform.GetChild(0).childCount;
    }
}
