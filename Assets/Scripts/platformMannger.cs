using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMannger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformPrefabs;
    [SerializeField]
    private int z_Offset;

    void Start()
    {
        for(int i =0; i < _platformPrefabs.Length; i++)
        {
            if(i == 0)
            {
                Instantiate(_platformPrefabs[i],new Vector3(0, 0, i * 12),Quaternion.Euler(0,0,0));
                z_Offset += 12;
            }
            else
            {
                
                Instantiate(_platformPrefabs[Random.Range(0,_platformPrefabs.Length )],new Vector3(0, 0, i * 12),Quaternion.Euler(0,0,0));
                z_Offset += 12;
            }
        }
    }

    public void RecyclePlatform(GameObject platform)
    {
        // reponsible for reposition next z offset
        platform.transform.position = new Vector3 (0, 0, z_Offset);
        z_Offset += 12;
        //Debug.Log("New location is assinged  " + z_Offset);
    }
}
