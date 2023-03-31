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
    [SerializeField] GameObject BoostFlamesPrefab;


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
            transform.localPosition = new Vector3(Mathf.Clamp(touchPosX, leftLimit, rightLimit), 0.24f, Mathf.Clamp(touchPosZ, backwardLimit, forwardtLimit));
        }
        else 
        {
            cinemachineDollyCart.m_Speed = 0f;
            BoostFlamesPrefab.transform.localScale = new Vector3(0, 0, 0);
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

            // changing local position of car to boosting and breaking effect of car base on fingure screen position 
            cinemachineDollyCart.m_Speed = inputConvert(transform.localPosition.z, backwardLimit, forwardtLimit, minSpeed, maxSpeed);

            // changing size of boost flames base on car local positions
            BoostFlamesPrefab.transform.localScale = new Vector3(1, 1,inputConvert(transform.localPosition.z, 0f, forwardtLimit, 0, 1));
            
        }

        

        if(transform.localPosition.z <= 0)
        {
            // seting size to zero if not boosting i.e car local z position is less than zero
            BoostFlamesPrefab.transform.localScale = new Vector3(0,0,0);
           
            
        }
        else if (transform.localPosition.z == backwardLimit)
        {
            Debug.Log("Braking!!");
        }
        else {
            Debug.Log("Normal");
        }


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
