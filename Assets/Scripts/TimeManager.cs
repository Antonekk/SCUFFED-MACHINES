using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : RaceElement
{
    public TextMeshProUGUI timer;

    public TextMeshProUGUI countdown_text;
    public float current_time;

    private float countdown_timer;
    void Awake()
    {
        countdown_timer = 3f;
        current_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (app.rc_model.is_game_on)
        {
            TimerUpdate();
        }
        if (app.rc_model.countdown_state)
        {
            CountdownUpdate();
        }
    }


    void ResetTimer(){
        current_time = 0;
    }
    void TimerUpdate(){
        current_time += Time.deltaTime;
        timer.text = current_time.ToString("0.00");
    }
    void CountdownUpdate()
    {
        if(countdown_timer > 0)
        {
            countdown_timer -= Time.deltaTime;
        }
        else{
            app.rc_model.countdown_state = false;
            app.rc_model.is_game_on = true;
            countdown_timer = 0f;
            countdown_text.gameObject.SetActive(false);
        }
        countdown_text.text = countdown_timer.ToString("0");
    }
}
