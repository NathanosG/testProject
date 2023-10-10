using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    //
    public Rigidbody rb;
    public float speed;
    public float maxSpeed;
    //

    public bool canMove=true;

    void Start()
    {
        //
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(rb.centerOfMass.x, rb.centerOfMass.y-0.5f, rb.centerOfMass.z);
        speed = rb.velocity.magnitude;
        canMove = true;
        //
        maxSpeed = 13f;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            //
            speed = rb.velocity.magnitude;
            //

            if (speed > maxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }

            currentAcceleration = acceleration * Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakingForce;
            }
            else
            {
                currentBreakForce = 0f;
            }


            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;


            frontRight.brakeTorque = currentBreakForce;
            frontLeft.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;
            backRight.brakeTorque = currentBreakForce;

            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;

            UpdateWheel(frontLeft, frontLeftTransform);
            UpdateWheel(frontRight, frontRightTransform);
            UpdateWheel(backLeft, backLeftTransform);
            UpdateWheel(backRight, backRightTransform);
        }
        else
        {
            speed = rb.velocity.magnitude;
            currentAcceleration = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakingForce;
            }
            else
            {
                currentBreakForce = 0f;
            }

            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;

            frontRight.brakeTorque = currentBreakForce;
            frontLeft.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;
            backRight.brakeTorque = currentBreakForce;

            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;

            UpdateWheel(frontLeft, frontLeftTransform);
            UpdateWheel(frontRight, frontRightTransform);
            UpdateWheel(backLeft, backLeftTransform);
            UpdateWheel(backRight, backRightTransform);
        }


    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
