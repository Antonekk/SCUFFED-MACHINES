using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoost : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("AI") || other.CompareTag("Player2"))
        {
            StartCoroutine(other.GetComponent<SpawnController>().acc.ChangeAccelerationInTime(0.5f, 160));
        }
    }
}
