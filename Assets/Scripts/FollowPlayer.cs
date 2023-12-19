using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
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

    void LateUpdate()
    {

        if (!was_flagged && did_anim_ended)
        {
            rm_animator();
            was_flagged = true;
        }
        transform.position = new Vector3(player.position.x,y_pos,player.position.z);
    }
}
