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
        transform.eulerAngles += sensitivity * new Vector3 (-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), /*-Input.GetAxis("Mouse Y")*/0);
        if ((transform.eulerAngles.x >30) && (transform.eulerAngles.x<181))
        {
            transform.eulerAngles = new Vector3(30, transform.eulerAngles.y, 0);
        };
        if ((transform.eulerAngles.x<330) && (transform.eulerAngles.x>180))
        {
            transform.eulerAngles = new Vector3(330,transform.eulerAngles.y, 0);
        };

    }
}
