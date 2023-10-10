using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    //public NavMeshAgent agent;
    public float speed = 0f;
    public float maxSpeed = 15f;
    public float acceleration = 1f;
    private float x;
    private float z;
    private float angle;
    private Vector3 total;
    private int state=0;
    private Status status;
    public bool canMove=true;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        status = transform.gameObject.GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            angle = transform.eulerAngles.y;
            x = Mathf.Cos((angle / 180) * Mathf.PI);
            z = Mathf.Sin((angle / 180) * Mathf.PI);
            total = new Vector3(0,0,0);

            if (Input.GetKey("w") && !(Mathf.Floor(speed) > 0 && state == 1) && status.petrol > 0)
            {
                state = 0;
                if (Input.GetKey("a") && speed > 1)
                {
                    transform.eulerAngles += new Vector3(0, -((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                }
                if (Input.GetKey("d") && speed > 1)
                {
                    transform.eulerAngles += new Vector3(0, ((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                }
                total += new Vector3(z, 0, x);
                if (speed < maxSpeed)
                {
                    speed += 0.005f*acceleration;
                }
            }

            if (Input.GetKey("s") && !(Mathf.Floor(speed) > 0 && state == 0) && status.petrol > 0)
            {
                state = 1;
                if (Input.GetKey("a") && speed > 1)
                {
                    transform.eulerAngles += new Vector3(0, ((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                }
                if (Input.GetKey("d") && speed > 1)
                {
                    transform.eulerAngles += new Vector3(0, -((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                }
                total += new Vector3(-z, 0, -x);
                if (speed < 0.5*maxSpeed)
                {
                    speed += 0.005f*acceleration;
                }
            }

            if (!Input.GetKey("w") && !Input.GetKey("s") || status.petrol == 0)
            {
                if (speed > 0.01f)
                {
                    speed -= 0.01f*acceleration;
                    if (state == 0)
                    {
                        total += new Vector3(z, 0, x);
                        if (Input.GetKey("a") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, -((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                        if (Input.GetKey("d") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, ((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                        
                    }
                    else if (state == 1)
                    {
                        total += new Vector3(-z, 0, -x);
                        if (Input.GetKey("a") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, ((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                        if (Input.GetKey("d") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, -((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                    }
                }
                else
                {
                    speed = 0;
                }

            }
            else if (Input.GetKey("s") && (Mathf.Floor(speed) > 0 && state == 0) || Input.GetKey("w") && (Mathf.Floor(speed) > 0 && state == 1))
            {
                if (speed > 0.01f)
                {
                    speed -= 0.02f*acceleration;
                    if (state == 0)
                    {
                        total += new Vector3(z, 0, x);
                        if (Input.GetKey("a") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, -((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                        if (Input.GetKey("d") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, ((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                        
                    }
                    else if (state == 1)
                    {
                        total += new Vector3(-z, 0, -x);
                        if (Input.GetKey("a") && speed > 1)
                        {
                            transform.eulerAngles += new Vector3(0, ((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                        if (Input.GetKey("d") )
                        {
                            transform.eulerAngles += new Vector3(0, -((0.11f/0.15f)*speed/(20*speed/5))/*0.15f*/, 0);
                        }
                    }
                }
                else
                {
                    speed = 0;
                }
            }
            transform.position += Vector3.Normalize(total) * Time.deltaTime * speed;
        }
    }
}
