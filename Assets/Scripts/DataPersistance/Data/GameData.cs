using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public static bool newGame = false;

    public float woodAmount;
    public float stoneAmount;
    public float steelAmount;
    public float goldAmount;

    public Vector3 playerPosition;
    public GameData()
    {
        if (newGame == true)
        {
            this.woodAmount = 0;
            this.stoneAmount = 0;
            this.steelAmount = 0;
            this.goldAmount = 0;

            playerPosition = mainCharacter.playerPosition;

            newGame = false;
        }
        else
        {
            this.woodAmount = 0;
            this.stoneAmount = 0;
            this.steelAmount = 0;
            this.goldAmount = 0;

            playerPosition = mainCharacter.playerPosition;
        }
    }
}
