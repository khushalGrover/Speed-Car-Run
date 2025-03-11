using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCOLLideing : MonoBehaviour
{
    public canvasManager canvases;

    void Awake()
    {
        canvases = GameObject.FindObjectOfType<canvasManager>();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player")
        {
            
            Movement.isAlive = false;
            canvases.gameOver();

        }
    }

}
