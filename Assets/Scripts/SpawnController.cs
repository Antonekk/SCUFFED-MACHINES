using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : RaceElement
{
    public GameObject last_checkpoint;
    public GameObject first_checkpoint;
    public Rigidbody car_rb;
    void Start()
    {
        last_checkpoint = first_checkpoint;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Respawn()
    {
        car_rb.transform.position = last_checkpoint.transform.position;
        car_rb.velocity = new Vector3(0f,0f,0f);
        car_rb.transform.rotation = last_checkpoint.transform.rotation;
    }
}
