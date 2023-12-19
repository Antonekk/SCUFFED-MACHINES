using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RaceElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    public RaceApplication app { get { return GameObject.FindObjectOfType<RaceApplication>(); } }
}

public class RaceApplication : MonoBehaviour
{
    // Reference to the root instances of the MVC.
    public RaceModel rc_model;
    public RaceView rc_view;
    public RaceController rc_controller;

    // Init things here
    void Awake() {
        rc_model = transform.GetChild(0).GetComponent<RaceModel>();
        rc_controller = transform.GetChild(1).GetComponent<RaceController>();
        rc_view = transform.GetChild(2).GetComponent<RaceView>();
        
    }
}
