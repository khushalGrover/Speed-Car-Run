using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollider : MonoBehaviour
{
    public int coinValue = 1;
    public ScoreS scoress;
    public GameObject coinPrefab;

    void Awake()
    {
        scoress = GameObject.FindObjectOfType<ScoreS>();
        coinPrefab = this.gameObject;
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player")
        {
            // Debug.Log("coin collected");
            scoress.coinCollected += coinValue;
            coinPrefab.SetActive(false);
            Invoke("RespwanCoin", 5.0f);
            //Destroy(this);
            // to do de activate this obj
        }
    }

    public void RespwanCoin()
    {
        coinPrefab.SetActive(true);
    }

}
