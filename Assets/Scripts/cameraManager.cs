using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class cameraManager : MonoBehaviour
{
     
    public GameObject[] Cameras;
     
    int currentCam;
     
    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        setCam(currentCam);
    }
 
    // Update is called once per frame
    void Update()
    {
         
    }
     
    public void setCam(int idx){
        for(int i = 0; i < Cameras.Length; i++)
        {
            if(i == idx)
            {
                Cameras[i].SetActive(true);
            }else
            {
                Cameras[i].SetActive(false);
            }
        }
    }
     
    public void toggleCam()
    {
        currentCam++;
        if(currentCam > Cameras.Length-1)
            currentCam = 0;
        setCam(currentCam);
    }
}
