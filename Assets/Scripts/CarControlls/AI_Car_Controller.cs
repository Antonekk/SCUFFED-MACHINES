using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AI_Car_Controller : RaceElement
{
    private Arcade_Car_controler acc;
    public SpawnController spawnController;
    public Transform checkpoints;

    private List<Transform> all_checkpoints_transform;

    private GameObject current_checkpoint;

    private Vector3 checkpoint_position;

    private bool is_running;
    void Start()
    {
        is_running = true;
        all_checkpoints_transform = new List<Transform>();
        for (int i = 0; i < app.rc_model.laps_count; i++)
        {
            foreach (Transform c in checkpoints)
            {
                all_checkpoints_transform.Add(c);
            }
        }
        all_checkpoints_transform.Add(all_checkpoints_transform[0]);
        acc = GetComponent<Arcade_Car_controler>();
        current_checkpoint = all_checkpoints_transform[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(is_running && app.rc_model.is_game_on)
        {
            float forward;
            float turn;

            Vector3 checkpoint_dir = (checkpoint_position - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, checkpoint_dir);
            forward = (dot > 0) ? 1f : -1f;

            float checkpoint_angle = Vector3.SignedAngle(transform.forward, checkpoint_dir, Vector3.up);
            turn = (checkpoint_angle > 0) ? 1f : -1f;
            acc.Player_Car_Controlls(forward, turn);
            SetCheckpointPos();
        }
        else
        {
            acc.Player_Car_Controlls(0, 0);
        }

    }

    public void SetCheckpointPos()
    {
        if (current_checkpoint == spawnController.last_checkpoint)
        {
            if (all_checkpoints_transform.Count == 0)
            {
                is_running = false;
                app.rc_model.did_ai_finished = !app.rc_model.has_player_won;
                return;
            }
            current_checkpoint = all_checkpoints_transform[0].gameObject;
            all_checkpoints_transform.RemoveAt(0);

        }
        this.checkpoint_position = current_checkpoint.transform.position;
    }
}