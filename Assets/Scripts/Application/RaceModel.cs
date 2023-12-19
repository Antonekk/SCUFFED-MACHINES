using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceModel : RaceElement
{
    public TextMeshProUGUI show_winner;


    public int laps_count;
    public bool is_game_on;
    public int finish_line_collisions_count;
    public bool countdown_state;
    public bool has_player_won;
    public bool did_ai_finished;

    public TextMeshProUGUI laps_left_gui;

    public AudioSource race_music;
    public AudioSource PlayerWinSoundEffect;
    public AudioSource PlayerLostSoundEffect;

    public bool show_winner_flag;
    void Awake()
    {
        show_winner_flag = false;
        countdown_state = true;
        finish_line_collisions_count = 0;
        is_game_on = false;
    }
}
