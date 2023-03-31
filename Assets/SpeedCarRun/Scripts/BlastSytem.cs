using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSytem : MonoBehaviour
{
    [SerializeField] GameObject expolostionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obstacles")
        {
            Instantiate(expolostionPrefab, transform.position , transform.rotation);
            Debug.Log("Enter Collided!!!");
        }
    }
}
