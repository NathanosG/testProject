using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject path;
    private Vector3[] destinations;
    private int destIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        destinations = new Vector3[path.transform.childCount];
        for (int i = 0; i < path.transform.childCount; i++)
        {
            destinations[i] = path.transform.GetChild(i).position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.transform.position.x == agent.destination.x && agent.transform.position.z == agent.destination.z)
        {
            destIndex += 1;
            if (destIndex == destinations.Length)
            {
                destIndex = 0;
                agent.Warp(destinations[destIndex]);
            }
            agent.SetDestination(destinations[destIndex]);
        }
    }
}
