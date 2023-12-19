using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsView : MonoBehaviour
{
    public List<CheckPointController> checkpoints;

    // Update is called once per frame
    void Awake()
    {
        checkpoints = new List<CheckPointController>();

        foreach (Transform c in transform)
        {
            checkpoints.Add(c.GetComponent<CheckPointController>());
        }

    }
}
