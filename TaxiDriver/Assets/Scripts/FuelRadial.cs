using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelRadial : MonoBehaviour
{
    public GameObject car;
    private Status status;
    private Image scaler;
    // Start is called before the first frame update
    void Start()
    {
        status = car.GetComponent<Status>();
        scaler = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        scaler.fillAmount = 0.35f*status.petrol/status.maxPetrol;
    }
}
