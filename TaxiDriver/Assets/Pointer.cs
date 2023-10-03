using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform target;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        Vector3 newPosition = player.position;
        newPosition.y = player.position.y+0.15f;
        transform.position = newPosition;

        
        transform.LookAt(new Vector3(target.position.x, transform.position.y,target.position.z));
    }
}
 