using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Winner : RaceElement
{
    public SpawnController player1;
    public SpawnController player2;


    public float y_pos;
    public GameObject camera_animator;

    public bool did_anim_ended;
    private bool was_flagged;
    


    private void Start()
    {
        did_anim_ended = false;
        was_flagged = false;
    }




    public void rm_animator()
    {
        camera_animator.GetComponent<Animator>().enabled = false;
    }
    public Transform WhoIsFurther()
    {
        if(player1.how_many_visited > player2.how_many_visited)
        {
            return player1.transform;
        }
        else if(player1.how_many_visited < player2.how_many_visited)
        {
            return player2.transform;
        }
        else { 
            return (player1.CalcluateDistanceToNextCheckpoint() > player2.CalcluateDistanceToNextCheckpoint()) ? player2.transform : player1.transform;
        }
    }


    void LateUpdate()
    {

        if (!was_flagged && did_anim_ended)
        {
            rm_animator();
            was_flagged = true;
        }

        Transform p = WhoIsFurther();
        transform.position = new Vector3(p.position.x, y_pos, p.position.z);
    }


}
