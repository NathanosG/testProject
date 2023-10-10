using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    public bool open=false;

    private Vector3 targetPos;
    private Vector3 currentPos;
    private Vector3 originalPos;

    private Vector3 targetRotation;
    private Vector3 currentRotation;
    private Vector3 originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.localPosition;
        currentPos = transform.localPosition;
        originalPos = transform.localPosition;

        targetRotation = transform.localEulerAngles;
        currentRotation = transform.localEulerAngles;
        originalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            targetPos = new Vector3(originalPos.x+0.5f, 0.66f, originalPos.z);
            currentPos = Vector3.Lerp(currentPos, targetPos, Time.deltaTime);
            transform.localPosition = currentPos;

            targetRotation = new Vector3(originalRotation.x, originalRotation.y, 90f);
            currentRotation = Vector3.Lerp(currentRotation, targetRotation, Time.deltaTime);
            transform.localEulerAngles = currentRotation;
        }
        else
        {
            targetPos = originalPos;
            currentPos = Vector3.Lerp(currentPos, targetPos, Time.deltaTime);
            transform.localPosition = currentPos;

            targetRotation = originalRotation;
            currentRotation = Vector3.Lerp(currentRotation, targetRotation, Time.deltaTime);
            transform.localEulerAngles = currentRotation;
        }
    }
}
