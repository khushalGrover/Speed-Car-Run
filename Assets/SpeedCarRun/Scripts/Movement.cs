using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Movement : MonoBehaviour
{

    public static bool isAlive = true;

    public bool isTouching = false;
    public CinemachineDollyCart cinemachineDollyCart;

    [Header("______car controlls_____")]
    [Tooltip("Car Controlls")] 
    [SerializeField] float controlSpeed;
    [SerializeField] float leftLimit = -1.4f;
    [SerializeField] float rightLimit = 1.4f;
    [SerializeField] float forwardtLimit = 3f;
    [SerializeField] float backwardLimit = -1.4f;
    [SerializeField] float maxSpeed = 25f;
    [SerializeField] float minSpeed = 2f;

    [Header("_____Boost UI _____")]
    [Tooltip("Boost UI Element")] 
    public string CurrentBoostText = "";
    [SerializeField] TMP_Text CurrentBoost;
    [SerializeField] TMP_Text CurrentBoostMultiplyer;

    [SerializeField] GameObject BoostFlamesPrefab;
    [SerializeField] SpriteRenderer BoostEffectUI;
    [SerializeField] Color BoostEffect_Color;
    [SerializeField] GameObject WindEffectPrefab;


    public float touchPosX;
    public float touchPosZ;

    [Header("______FUEL SYSTEM_____")]
    [Tooltip("FuelSystem")]    
    public TMP_Text fuelDisplay;
    public Slider slider;
    [SerializeField] float currentFuel = 100f;
    [SerializeField] float reduceRate = 0.1f;
    [SerializeField] float fillRate = 0.5f;
    // [SerializeField] GameObject expolostionPrefab;
    public canvasManager canvases;

    void Awake()
    {
        canvases = GameObject.FindObjectOfType<canvasManager>();
    }

    void Start()
    {
        isAlive = true;
        BoostEffect_Color.a = 0f;
        CurrentBoostMultiplyer.faceColor = new Color(255, 255, 255, 0);
    }
    void Update()
    {
        if (isAlive)
        {
            checkInput();
            inputPC();
            FuelReduceSystem();
            transform.localPosition = new Vector3(Mathf.Clamp(touchPosX, leftLimit, rightLimit), 0.24f, Mathf.Clamp(touchPosZ, backwardLimit, forwardtLimit));
            BoostEffectUI.color = BoostEffect_Color;
        }
        else
        {
            cinemachineDollyCart.m_Speed = 0f;
            BoostFlamesPrefab.transform.localScale = new Vector3(0, 0, 0);
            WindEffectPrefab.transform.localScale = new Vector3(0, 0, 0);
            BoostEffect_Color.a = 0f;
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "FuelTank")
        {
            // Refill fuel
            fueling();
        }
        // else if (collisionInfo.collider.tag == "obstacles")
        // {
        //     Instantiate(expolostionPrefab, transform.position, transform.rotation);
            
        //     Debug.Log("Collided!!!");
        // }
    }

    void FuelReduceSystem()
    {
        fuelDisplay.text = currentFuel.ToString("0");
        slider.value = currentFuel;

        if(currentFuel > 0 && isAlive == true)
        {
            currentFuel -= reduceRate * Time.deltaTime;
        }
        else if(currentFuel <= 0)
        {
            // emty tank
            
            isAlive = false;
            canvases.gameOver();
        } 
    }

    void fueling()
    {
        if(currentFuel <= (99-fillRate))
        {
            currentFuel += fillRate;
            // currentFuel = 100;
        }
        else 
        {
            //already full
            // Debug.Log("fuel tank is full");
            currentFuel = 100;
        }
    }

    void inputPC()
    {
        if (isTouching)
        {
            float movDirX = Input.GetAxis("Mouse X");
            float movDirZ = Input.GetAxis("Mouse Y");
            touchPosX += movDirX * controlSpeed * Time.fixedDeltaTime;
            touchPosZ += movDirZ * controlSpeed * Time.fixedDeltaTime;

            // changing local position of car to boosting and breaking effect of car base on fingure screen position 
            cinemachineDollyCart.m_Speed = inputConvert(transform.localPosition.z, backwardLimit, forwardtLimit, minSpeed, maxSpeed);

            // changing size of boost flames base on car local positions
            BoostFlamesPrefab.transform.localScale = new Vector3(1, 1, inputConvert(transform.localPosition.z, 0f, forwardtLimit, 0, 1));
            WindEffectPrefab.transform.localScale = new Vector3(1, 1, inputConvert(transform.localPosition.z, backwardLimit, 0f, 1, 0));
            BoostEffect_Color.a = inputConvert(transform.localPosition.z, 0f, forwardtLimit, 0, 1);

            // changing Bost UI 
            CurrentBoost.text = cinemachineDollyCart.m_Speed.ToString("0");
            // CurrentBoost.text = inputConvert((transform.localPosition.z), 0, forwardtLimit, 0, 3).ToString("0");
            CurrentBoostMultiplyer.text = "X" + (inputConvert(transform.localPosition.z, 0, forwardtLimit, 0, 10)).ToString("0"); // sahi hai
            CurrentBoostMultiplyer.faceColor = new Color(255, 255, 255, inputConvert((transform.localPosition.z), 0, forwardtLimit, 0, 1));
            // CurrentBoostText = "" + (inputConvert(transform.localPosition.z, backwardLimit, forwardtLimit, 0, 1)).ToString("0");
        }



        if (transform.localPosition.z <= 0)
        {
            // seting size to zero if not boosting i.e car local z position is less than zero
            BoostFlamesPrefab.transform.localScale = new Vector3(0, 0, 0);

        }
        // else if (transform.localPosition.z == backwardLimit)
        // {
        //     Debug.Log("Braking!!");
        // }
        // else
        // {
        //     Debug.Log("Normal");
        // }


    }

    void checkInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    float inputConvert(float num, float in_min, float in_max, float out_min, float out_max)
    {
        return (num - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

}
