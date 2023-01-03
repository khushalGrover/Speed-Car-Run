using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    
    private Vector3 MoveForce;
    public float MoveSpeed = 50;
    public float Drag = 0.98f;
    public float MaxSpeed = 15;
    public float SteerAngle = 20;
    public float Traction = 20;
    public bool isDrift = false;
    public GameObject taril;
    public FixedJoystick joystick;
    public float steerInput;



    // Update is called once per frame
    void Update()
    {
        // move
        MoveForce += transform.forward * MoveSpeed * 0.1f * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Steering
        steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
        
        // Drag and max speed limit 
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if(joystick.Horizontal != 0)
            {
                steerInput = joystick.Horizontal;
                transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
                Debug.Log("Horizonatl axis joy stick");
            }
            if(joystick.Vertical != 0)
            {
                // steerInput = joystick.Vertical;
                MoveForce += transform.forward * MoveSpeed * joystick.Vertical * Time.deltaTime;
                Debug.Log("Vertical move");
            }
                
        }

        if(Input.GetKey("space"))
        {
            isDrift = true;
        }
        else
        {
            isDrift = false;
        }

       
        if(isDrift)
        {
            // Debug.Log("Hand break is on and Drifiting....");
            SteerAngle = 15;
            Traction = 1f;
            Drag = 0.97f;
            taril.SetActive(true);
        }
        else
        {
            // Debug.Log("normal mode");
            SteerAngle = 5;
            Traction = 20f;
            Drag = 0.98f;
            taril.SetActive(false);
        }
        // Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }



}
