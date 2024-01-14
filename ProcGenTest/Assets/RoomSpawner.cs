using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 bottom
    //2 top door
    //3 left door
    //4 right door
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn() 
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //spawn south room
                rand = Random.Range(0, templates.southRooms.Length);
                Instantiate(templates.southRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                //spawn north room
                rand = Random.Range(0, templates.northRooms.Length);
                Instantiate(templates.northRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                //spawn west door
                rand = Random.Range(0, templates.westRooms.Length);
                Instantiate(templates.westRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                //spawn east door
                rand = Random.Range(0, templates.eastRooms.Length);
                Instantiate(templates.eastRooms[rand], transform.position, Quaternion.identity);
            }
            spawned = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
