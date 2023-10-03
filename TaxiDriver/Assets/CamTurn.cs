using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTurn : MonoBehaviour
{
    public float sensitivity = 2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += sensitivity * new Vector3 (0, Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        if ((transform.eulerAngles.z >30) && (transform.eulerAngles.z<181))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 30);
        };
        if ((transform.eulerAngles.z<330) && (transform.eulerAngles.z>180))
        {
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y, 330);
        };

    }
}
