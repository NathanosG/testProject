using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float balance;
    public float crimeLevel;

    public GameObject[] cars;
    public GameObject camera;
    public int currentCar=0;
    public GameObject jobs;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            int prevInd = currentCar;
            if (currentCar < cars.Length-1){
                currentCar += 1;
            }
            else
            {
                currentCar = 0;
            }
            ChangeCar(prevInd);
        }
    }

    void ChangeCar(int prevInd)
    {
        Vector3 pos = cars[prevInd].transform.position;
        Quaternion rot = cars[prevInd].transform.rotation;
        Vector3 camPos = camera.transform.localPosition;
        Quaternion camRot = camera.transform.localRotation;
        camera.transform.parent = cars[currentCar].transform;
        cars[prevInd].SetActive(false);
        cars[currentCar].SetActive(true);
        cars[currentCar].transform.position = pos;
        camera.transform.localPosition = camPos;
        cars[currentCar].transform.rotation = rot;
        camera.transform.localRotation = camRot;
    }
}
