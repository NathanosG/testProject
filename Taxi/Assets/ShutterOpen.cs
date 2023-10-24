using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterOpen : MonoBehaviour
{
    public GameObject garageDoor;
    private GarageDoor script;
    // Start is called before the first frame update
    void Start()
    {
        script = garageDoor.GetComponent<GarageDoor>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Substring(0,4) != "tile")
        {
            script.open = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Substring(0,4) != "tile")
        {
            script.open = false;
        }

    }
}
