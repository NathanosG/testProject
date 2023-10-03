using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLifter : MonoBehaviour
{
    private Vector3 targetPos;
    private Vector3 currentPos;
    private Vector3 originalPos;

    public GameObject car;

    public bool lift=false;
    void Start()
    {
        targetPos = transform.position;
        currentPos = transform.position;
        originalPos = transform.position;
    }

    void FixedUpdate()
    {
        if (lift)
        {
            targetPos = new Vector3(originalPos.x, originalPos.y+2,originalPos.z);
            currentPos = Vector3.Lerp(currentPos, targetPos, Time.deltaTime);
            transform.position = currentPos;
        }
        else
        {
            targetPos = originalPos;
            currentPos = Vector3.Lerp(currentPos, targetPos, Time.deltaTime);
            transform.position = currentPos;
        }
    }
    public void Lift()
    {
        lift = !lift;
    }
}
