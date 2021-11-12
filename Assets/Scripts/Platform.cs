using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private platformMannger _platformManager;

    private void OnEnable() 
    {
        _platformManager  = GameObject.FindObjectOfType<platformMannger>();
        
    }

    private void OnBecameInvisible() 
    {
        // Recycle this platform
        _platformManager.RecyclePlatform(this.gameObject);    
        //Debug.Log("This is GameObject is not Visiable");
    }
}
