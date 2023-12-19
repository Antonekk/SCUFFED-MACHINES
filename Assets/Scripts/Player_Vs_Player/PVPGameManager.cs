using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PVPGameManager : RaceElement
{
    // Update is called once per frame

    public Camera cam;

    bool isP1Respawning;
    bool isP2Respawning;

    private void Start()
    {
    }
    void Update()
    {
        if (!app.rc_model.countdown_state)
        {
            CheckForRespawn();
        }
        
        if (app.rc_model.finish_line_collisions_count >= app.rc_model.laps_count)
        {
            app.rc_model.is_game_on = false;

            app.rc_model.has_player_won = !app.rc_model.did_ai_finished;
            if (!app.rc_model.show_winner_flag)
            {
                ShowWinner();
            }

        }
        ShowScore();

    }


    void ShowScore()
    {
        app.rc_model.laps_left_gui.text = "To: " + app.rc_model.KillNum.ToString() + " Kills   " + app.rc_model.Player1.GetComponent<PlayerModel>().KillsCount.ToString() + "-" + app.rc_model.Player2.GetComponent<PlayerModel>().KillsCount.ToString();
    }

    void CheckForRespawn()
    {
        PlayerModel PM1 = app.rc_model.Player1.GetComponent<PlayerModel>();
        PlayerModel PM2 = app.rc_model.Player2.GetComponent<PlayerModel>();
        if (!IsObjOnCamera(PM1.car_mesh) && !isP1Respawning)
        {
            PM1.SpC.RespawnT(PM2.SpC.next_checkpoint.transform);
            Debug.Log("Add to PM1");
            PM2.KillsCount++;
            isP1Respawning = true;
            PM1.SpC.how_many_visited = PM2.SpC.how_many_visited;


        }
        else if (IsObjOnCamera(PM1.car_mesh) && isP1Respawning)
        {
            isP1Respawning = false;
          
        }


        if (!IsObjOnCamera(PM2.car_mesh) && !isP2Respawning)
        {
            PM2.SpC.RespawnT(PM1.SpC.next_checkpoint.transform);
            PM2.SpC.how_many_visited = PM1.SpC.how_many_visited;
            Debug.Log("Add to PM2");
            PM1.KillsCount++;
            isP2Respawning = true;
        }
        else if(IsObjOnCamera(PM2.car_mesh) && isP2Respawning)
        {
            isP2Respawning = false;
        }
    }
    void ShowWinner()
    {
        app.rc_model.race_music.Stop();
        app.rc_model.show_winner.gameObject.SetActive(true);
        if (app.rc_model.has_player_won == true)
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


    public bool IsObjOnCamera(GameObject g)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(g.transform.position);
        if((viewPos.x > 0f && viewPos.x < 1f) && (viewPos.y > 0f && viewPos.y < 1f) && viewPos.z > 0f)
        {
            return true;
        }
        return false;
        
    }

}
