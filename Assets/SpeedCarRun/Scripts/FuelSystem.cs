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
    // [SerializeField] GameObject expolostionPrefab;
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

        if(currentFuel > 0 && Movement.isAlive == true)
        {
            currentFuel -= reduceRate * Time.deltaTime;
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

}
