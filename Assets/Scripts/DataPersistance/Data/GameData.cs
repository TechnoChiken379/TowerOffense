using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float woodAmount;
    public float stoneAmount;
    public float steelAmount;
    public float goldAmount;

    public Vector3 playerPosition;

    public bool enemyIsDead;

    public Dictionary<string, bool> deadEnemy;
    public GameData()
    {
        this.woodAmount = 0;
        this.stoneAmount = 0;
        this.steelAmount = 0;
        this.goldAmount = 0;

        playerPosition = Vector3.zero;

        this.enemyIsDead = false;

        deadEnemy = new Dictionary<string, bool>();
    }
}
