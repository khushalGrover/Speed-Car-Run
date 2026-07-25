 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public int b = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("q"))
        {
            b++;
        }
        else if(Input.GetKeyUp("e") && b>0)
        {
            b--;
        }
    }
}
