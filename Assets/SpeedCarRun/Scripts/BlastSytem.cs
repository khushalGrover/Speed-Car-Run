using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSytem : MonoBehaviour
{
    [SerializeField] GameObject expolostionPrefab;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obstacles")
        {
            Instantiate(expolostionPrefab, transform.position , transform.rotation);
        }
    }
}
