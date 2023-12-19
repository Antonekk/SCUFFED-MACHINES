using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : RaceElement
{
    private Arcade_Car_controler acc;
    private readonly string HORIZONTAL = "Horizontal";
    private readonly string VERTICAL = "Vertical";
    void Awake()
    {
        acc = GetComponent<Arcade_Car_controler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (app.rc_model.is_game_on)
        {
            float vertical = Input.GetAxis(VERTICAL);
            float horizontal = Input.GetAxis(HORIZONTAL);
            acc.Player_Car_Controlls(vertical, horizontal);
        }
        else
        {
            acc.Player_Car_Controlls(0, 0);
        }
    }


}
