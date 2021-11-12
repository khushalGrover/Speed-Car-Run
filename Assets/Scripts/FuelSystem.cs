using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelSystem : MonoBehaviour
{
   
     [Header("______FUEL SYSTEM_____")]
    [Tooltip("FuelSystem")]    
    public TMP_Text fuelDisplay;
    public Slider slider;
    [SerializeField] float currentFuel = 100f;
    [SerializeField] float reduceRate = 0.1f;
    [SerializeField] float fillRate = 0.5f;
   
    
    public canvasManager canvases;
    

    // Start is called before the first frame update
    void Awake()
    {
        canvases = GameObject.FindObjectOfType<canvasManager>();
    }

    void Update()
    {
        FuelReduceSystem();
    }
    
    
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "FuelTank")
        {
            // Refill fuel
            fueling();
        }
    }

    void FuelReduceSystem()
    {
        fuelDisplay.text = "Fuel:" + currentFuel.ToString("0");
        slider.value = currentFuel;

        if(currentFuel > 0)
        {
            currentFuel -= reduceRate;
        }
        else if(currentFuel <= 0)
        {
            // emty tank
            
            Movement.isAlive = false;
            canvases.gameOver();
        } 
    }


    void fueling()
    {
        if(currentFuel < 99)
        {
            //currentFuel += fillRate;
            currentFuel = 100;
        }
        else if(currentFuel >= 100)
        {
            //already full
            Debug.Log("fuel tank is full");
            currentFuel = 100;
        }
    }

}
