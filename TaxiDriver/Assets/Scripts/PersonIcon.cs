using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonIcon : MonoBehaviour
{
    public GameObject cam;
    private float height;
    private float maxHeight;
    private float minHeight;
    private float target;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.position.y;
        maxHeight = height + 0.3f;
        minHeight = height - 0.3f;
        target = maxHeight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

        if (transform.position.y > target && target == minHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
        }
        else if (transform.position.y < target && target == maxHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2*Time.deltaTime, transform.position.z);
        }
        else
        {
            if (target == maxHeight)
            {
                target = minHeight;
            }
            else
            {
                target = maxHeight;
            }
        }
    }
}
