using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnController : RaceElement
{
    public GameObject last_checkpoint;
    public GameObject first_checkpoint;
    public GameObject next_checkpoint;

    public int how_many_visited;
    public Rigidbody car_rb;
    public Arcade_Car_controler acc;
    void Start()
    {
        last_checkpoint = first_checkpoint;
        next_checkpoint = first_checkpoint;
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

    public void RespawnT(Transform t)
    {
        car_rb.transform.position = t.position;
        car_rb.velocity = new Vector3(0f, 0f, 0f);
        car_rb.transform.rotation = t.rotation;
    }

    public float CalcluateDistanceToNextCheckpoint()
    {
        return Vector3.Distance(car_rb.transform.position, next_checkpoint.transform.position);
    }
}
