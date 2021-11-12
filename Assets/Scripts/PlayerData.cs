using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public int score;
    public int highNum;
    public int coinCollected;
    

    public PlayerData (ScoreS scored)
    {
        //score = scored.score;
        highNum = scored.highNum;
        coinCollected = scored.coinCollected;
    }
}
