using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : RaceElement
{
    private Arcade_Car_controler acc;
    private string HORIZONTAL = "Horizontal";
    private string VERTICAL = "Vertical";
    public bool is_using_wsad;

    void Awake()
    {
        if (is_using_wsad)
        {
            HORIZONTAL = "Horizontal";
            VERTICAL = "Vertical";
        }
        else
        {
            HORIZONTAL = "Horizontal_Arrows";
            VERTICAL = "Vertical_Arrows";
        }
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
