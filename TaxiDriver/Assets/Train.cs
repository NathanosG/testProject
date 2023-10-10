using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
        if (transform.position.x > 2000f)
        {
            transform.position = new Vector3(-230, transform.position.y, transform.position.z);
        }
    }
}
