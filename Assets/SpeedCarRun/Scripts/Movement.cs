using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class Movement : MonoBehaviour
{
    
    public static bool isAlive = true;
    
    public bool isTouching = false;
    public CinemachineDollyCart cinemachineDollyCart;
   
    [SerializeField] float controlSpeed;
    [SerializeField] float leftLimit = -1.4f;
    [SerializeField] float rightLimit = 1.4f;
    [SerializeField] float forwardtLimit = 3f;
    [SerializeField] float backwardLimit = -1.4f;
    [SerializeField] float maxSpeed = 25f;
    [SerializeField] float minSpeed = 2f;


    [SerializeField] int b = 0;

    public float touchPosX;
    public float touchPosZ;

    void Start()
    {
        isAlive = true;
       
    }

    void Update()
    {       
        if(isAlive)
        {
            checkInput();
            inputPC();
            transform.localPosition = new Vector3(Mathf.Clamp(touchPosX, leftLimit, rightLimit), 0.17f, Mathf.Clamp(touchPosZ, backwardLimit, forwardtLimit));
        }

    }



    void inputPC()
    {
       if(isTouching )
        {
            float movDirX = Input.GetAxis("Mouse X");
            float movDirZ = Input.GetAxis("Mouse Y");
            touchPosX += movDirX * controlSpeed * Time.fixedDeltaTime;
            touchPosZ += movDirZ * controlSpeed * Time.fixedDeltaTime;
            // currentSpeed = inputConvert(transform.localPosition.z, backwardLimit, forwardtLimit, minSpeed, maxSpeed);
            cinemachineDollyCart.m_Speed = inputConvert(transform.localPosition.z, backwardLimit, forwardtLimit, minSpeed, maxSpeed);
            // Debug.Log(cinemachineDollyCart.m_Speed);
        }

        

        // if(transform.localPosition.z == forwardtLimit)
        // {
        //     currentSpeed = inputConvert(transform.localPosition.z, backwardLimit, forwardtLimit, minSpeed, maxSpeed);
        // }
        // else if (transform.localPosition.z == backwardLimit)
        // {
        //     Debug.Log("Braking!!");
        // }
        // else {
        //     Debug.Log("Normal");
        // }


    }

    void checkInput()
    {
        if(Input.GetMouseButton(0)) 
        {
            isTouching=true;
        }
        else 
        {
            isTouching=false;
        }
    }

    float inputConvert(float num, float in_min, float in_max, float out_min, float out_max )
    {
        return (num - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
     
}
