using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedoHand : MonoBehaviour
{
    public GameObject car;
    //private Movement movement;
    private WheelController movement;
    private RectTransform spedo;
    // Start is called before the first frame update
    void Start()
    {
        movement = car.GetComponent<WheelController>();
        spedo = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        spedo.localEulerAngles = new Vector3(0,0,-movement.speed*8);
    }
}
