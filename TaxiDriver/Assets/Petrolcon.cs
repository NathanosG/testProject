using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Petrolcon : MonoBehaviour
{
    public GameObject car;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (car.GetComponent<Status>().petrol/car.GetComponent<Status>().maxPetrol < 0.3f)
        {  
            img.color = new Color(255,207,0);
        }
        else
        {
            img.color = new Color(0,0,0);
        }
    }
}
