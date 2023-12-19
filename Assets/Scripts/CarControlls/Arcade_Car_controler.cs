using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Arcade_Car_controler : RaceElement
{
    public Rigidbody car_RB;
    public Transform car_front_left_wheel, car_front_right_wheel;
    public float max_steering_angle;

    public float forward_acceleration, back_acceleration, max_car_speed, steering_strength,additional_gravity,car_drag;
    private float acceleration_boost = 100f, gravity_boost = 100f;
    private float acceleration_input, steering_input;


    private bool is_car_grounded;

    public LayerMask GroundLayer;
    public float ray_length;
    public Transform ray_point;

    private Vector3 car_shift = new(0f,0.5f,0f);

    public AudioSource engine;
    public float min_pitch;
    public float max_pitch;

    // Start is called before the first frame update

    void Start(){
      
    }

    void EngineSound()
    {
        float velo = car_RB.velocity.magnitude;
        float proc = 1f * velo / max_car_speed;
        if (velo > 0)
        {
            engine.pitch = ((max_pitch - min_pitch) * proc) + min_pitch;
        }
    }

    void HandleAcceleration(float vertical){
        acceleration_input = 0f;
        if(vertical>0){
            acceleration_input = forward_acceleration * vertical * acceleration_boost;
        }
        else if (vertical < 0){
            acceleration_input = back_acceleration * vertical * acceleration_boost;
        }
    }

    void HandleRotatingMeshes(){
        Vector3 left_wheel_euler = car_front_left_wheel.localRotation.eulerAngles;
        car_front_left_wheel.localRotation = Quaternion.Euler(left_wheel_euler.x, steering_input *max_steering_angle, left_wheel_euler.z);

        Vector3 right_wheel_euler = car_front_right_wheel.localRotation.eulerAngles;
        car_front_right_wheel.localRotation = Quaternion.Euler(right_wheel_euler.x,steering_input *max_steering_angle, right_wheel_euler.z);
    }

    void HandleSteering(float horizontal, float vertical){
        steering_input = horizontal;
        Vector3 new_rotation = new Vector3(0f,steering_input*steering_strength* Time.deltaTime*vertical ,0f);
        transform.rotation =  Quaternion.Euler(transform.rotation.eulerAngles + new_rotation);
        HandleRotatingMeshes();
    }

    public void Player_Car_Controlls(float vertical, float horizontal)
    {
        HandleAcceleration(vertical);
        if (is_car_grounded)
        {
            HandleSteering(horizontal,vertical);
        }
    }


    void Update(){

        transform.position = car_RB.transform.position - car_shift;
        EngineSound();
       
    }



    void HandleApplyingAcceleration(){
        if(is_car_grounded){
            car_RB.drag = car_drag;
            if(Mathf.Abs(acceleration_input) > 0){
                car_RB.AddForce(transform.forward *acceleration_input);
            }
        }
        else{
            car_RB.drag = 0.1f;
            car_RB.AddForce(additional_gravity * gravity_boost * -transform.up);
        }
    }
    void CheckForGround(){
        is_car_grounded = false;
        RaycastHit rc_hit;
        if(Physics.Raycast(ray_point.position, -transform.up, out rc_hit, ray_length, GroundLayer)){
            is_car_grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up,rc_hit.normal) * transform.rotation;
        }
    }

    void FixedUpdate(){
        CheckForGround();
        HandleApplyingAcceleration();
    }
}
