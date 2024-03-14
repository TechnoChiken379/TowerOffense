using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int woodAmount;
    public int stoneAmount;
    public int steelAmount;
    public int goldAmount;

    public GameData()
    {
        this.woodAmount = 0;
        this.stoneAmount = 0;
        this.steelAmount = 0;
        this.goldAmount = 0;
    }

}
