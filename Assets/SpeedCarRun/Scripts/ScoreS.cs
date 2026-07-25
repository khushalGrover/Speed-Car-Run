using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreS : MonoBehaviour
{
    [Header("______Player Score SYSTEM_____")]
    [Tooltip("PLayer score System")]    
    public Transform playerPrefab;
    public TMP_Text scoreText;
    public TMP_Text highText;
    public TMP_Text CoinText;
    public int highNum= 299;
    public int scoreNum;
    public int coinCollected;

    


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);

    
    }

    private void Start() {
        LoadPlayer();
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        highNum = data.highNum;
        highText.text = "" + highNum;

        coinCollected = data.coinCollected;
        CoinText.text = coinCollected.ToString("");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        scoreNum = Convert.ToInt32(playerPrefab.position.z);
        scoreText.text = "" + scoreNum.ToString("0");
        CoinText.text =  "" + coinCollected.ToString("");
        if(highNum < scoreNum)
        {
            
            highNum = scoreNum;
            highText.text = ""  + scoreNum;
            
            
        }
    }


    
    
}
