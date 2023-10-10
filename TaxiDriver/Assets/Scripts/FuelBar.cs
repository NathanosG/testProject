using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBar : MonoBehaviour
{
    public GameObject car;
    private Status status;
    private RectTransform scaler;
    // Start is called before the first frame update
    void Start()
    {
        status = car.GetComponent<Status>();
        scaler = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        scaler.localScale = new Vector3(scaler.localScale.x, (1-status.petrol/status.maxPetrol)*0.96f, 1);
    }
}
