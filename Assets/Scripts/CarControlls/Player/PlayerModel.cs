using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerModel : RaceElement
{

    public SpawnController SpC;
    public GameObject car_mesh;
    public GameObject car_ball;
    public int KillsCount;
    public Arcade_Car_controler acc;

    private void Start()
    {
        car_mesh = transform.GetChild(0).GetChild(0).gameObject;
        SpC =  transform.GetChild(1).GetComponent<SpawnController>();
        car_ball = transform.GetChild(1).gameObject;
        acc = transform.GetChild(0).GetComponent<Arcade_Car_controler>();

    }

}
