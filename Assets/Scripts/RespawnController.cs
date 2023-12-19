using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : RaceElement
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("AI") || other.CompareTag("Player2"))
        {
            other.GetComponent<SpawnController>().Respawn();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
