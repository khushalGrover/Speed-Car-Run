using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    
    public static bool isAlive = true;
    
    public bool isTouching = false;
   
    [SerializeField] float controlSpeed;
    [SerializeField] float leftLimit = -1.4f;
    [SerializeField] float rightLimit = 1.4f;

    public float touchPosX;

  



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
            transform.localPosition = new Vector3(Mathf.Clamp(touchPosX, leftLimit, rightLimit), 0.17f, 0);
            
        }

    }



    void inputPC()
    {
       if(isTouching )
        {
            float movDir = Input.GetAxis("Mouse X");
            
            touchPosX += movDir * controlSpeed *Time.fixedDeltaTime;

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


     
}
