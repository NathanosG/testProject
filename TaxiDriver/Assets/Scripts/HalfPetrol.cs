using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HalfPetrol : MonoBehaviour
{
    public GameObject car;
    private Status status;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        status = car.GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText((status.maxPetrol/2).ToString());
    }
}
