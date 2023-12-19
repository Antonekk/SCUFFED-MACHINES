using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVPCheckpointController : CheckpointsView
{
    public bool is_finish_line;
    public bool was_visited;
    public bool was_visited_by_player2;
    public List<GameObject> checkpoints_list;
    public GameObject Checkpoints_parent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            SpawnController spawnController = other.GetComponent<SpawnController>();


            if (other.CompareTag("Player2"))
            {
                if (!was_visited_by_player2)
                {
                    spawnController.how_many_visited++;
                    
                }
                was_visited_by_player2 = true;
                if (is_finish_line && Check_if_all_visided_Player2())
                {
                    app.rc_model.finish_line_collisions_count++;
                    ResetVisitedPlayer2();

                }
            }
            if (other.CompareTag("Player"))
            {
                if (!was_visited)
                {
                    spawnController.how_many_visited++;
                }
                was_visited = true;
                if (is_finish_line && Check_if_all_visided())
                {
                    app.rc_model.finish_line_collisions_count++;
                    ResetVisited();

                }
            }

            spawnController.last_checkpoint = gameObject;
            spawnController.next_checkpoint = Next_Checkpoint();

        }
    }


    GameObject Next_Checkpoint()
    {
        int index = checkpoints_list.LastIndexOf(gameObject);
        index++;
        return checkpoints_list[(index % checkpoints_list.Count)];
    }
    void ResetVisited()
    {
        foreach (GameObject g in checkpoints_list)
        {
            g.GetComponent<PVPCheckpointController>().was_visited = false;


        }
        checkpoints_list[0].GetComponent<PVPCheckpointController>().was_visited = true;
    }


    void ResetVisitedPlayer2()
    {
        foreach (GameObject g in checkpoints_list)
        {
            g.GetComponent<PVPCheckpointController>().was_visited_by_player2 = false;


        }
        checkpoints_list[0].GetComponent<PVPCheckpointController>().was_visited_by_player2 = true;
    }
    bool Check_if_all_visided()
    {
        int visited_count = 0;
        foreach (GameObject g in checkpoints_list)
        {
            if (g.GetComponent<PVPCheckpointController>().was_visited)
            {
                visited_count++;
            }
        }
        if (visited_count == checkpoints_list.Count)
        {
            return true;
        }
        return false;
    }

    bool Check_if_all_visided_Player2()
    {
        int visited_count = 0;
        foreach (GameObject g in checkpoints_list)
        {
            if (g.GetComponent<PVPCheckpointController>().was_visited_by_player2)
            {
                visited_count++;
            }
        }
        if (visited_count == checkpoints_list.Count)
        {
            return true;
        }
        return false;
    }

    /*
    bool Check_is_checkpoint_next(GameObject other)
    {
        int other_pos = checkpoints_list.IndexOf(other);
        int this_pos = checkpoints_list.IndexOf(gameObject);
        if(other_pos <= this_pos)
        {
            return false;
        }
        return true;
    }
    */

    void Awake()
    {
        Checkpoints_parent = transform.parent.gameObject;
        checkpoints_list = new List<GameObject>();
        foreach (Transform c in Checkpoints_parent.transform)
        {
            checkpoints_list.Add(c.gameObject);
        }
    }
}
