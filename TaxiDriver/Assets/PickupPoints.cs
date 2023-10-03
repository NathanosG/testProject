using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour
{
    public GameObject pointer;
    private Pointer pointerScript;
    // Start is called before the first frame update
    void Awake()
    {
        pointerScript = pointer.GetComponent<Pointer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void New()
    {
        float num = Mathf.Round(Random.Range(0,transform.childCount));
        transform.GetChild((int)num).gameObject.SetActive(true);
        pointerScript.target = transform.GetChild((int)num).transform;

    }
}
