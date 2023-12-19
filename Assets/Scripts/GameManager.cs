using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class GameManager : RaceElement
{


    // Update is called once per frame

    private void Start()
    {
        
    }
    void Update()
    {
        if (app.rc_model.finish_line_collisions_count >= app.rc_model.laps_count)
        {
            app.rc_model.is_game_on = false;

            app.rc_model.has_player_won = !app.rc_model.did_ai_finished;
            if (!app.rc_model.show_winner_flag)
            {
                ShowWinner();
            }
            
        }
        UpdateLapsLeft();

    }

    void ShowWinner()
    {
        app.rc_model.race_music.Stop();
        app.rc_model.show_winner.gameObject.SetActive(true) ;
        if(app.rc_model.has_player_won  == true)
        {
            app.rc_model.show_winner.color = Color.green;
            app.rc_model.PlayerWinSoundEffect.Play();
            app.rc_model.show_winner.text = "You won";
        }
        else
        {
            app.rc_model.show_winner.color = Color.red;
            app.rc_model.PlayerLostSoundEffect.Play();
            app.rc_model.show_winner.text = "You Lost";
        }
        app.rc_model.show_winner_flag = true;
    }
    void UpdateLapsLeft()
    {
        app.rc_model.laps_left_gui.text = "Laps left: " + (app.rc_model.laps_count - app.rc_model.finish_line_collisions_count).ToString("0");
    }


    

}
