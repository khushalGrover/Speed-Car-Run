using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCOLLideing : MonoBehaviour
{
    public canvasManager canvases;
    

    // Start is called before the first frame update
    void Awake()
    {
        canvases = GameObject.FindObjectOfType<canvasManager>();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player")
        {
            Debug.Log("Game Over");
            Movement.isAlive = false;
            canvases.gameOver();
        }
    }

}
