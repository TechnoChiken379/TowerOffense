using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class enemyTentFunction : MonoBehaviour
{
    //health
    private float enemyHP, enemyMaxHP = 50f;

    //death drop
    public GameObject deathDropGold;
    public GameObject deathDropWood;
    public GameObject deathDropStone;
    public GameObject deathDropSteel;

    //private float DroppedGold = 0;
    private float DroppedWood = 18;
    private float DroppedStone = 18;
    private float DroppedSteel = 9;

    public Transform deathDropPoint;

    //encampment
    public GameObject Encampment;


    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {

    }

    void Start()
    {
        enemyHP = enemyMaxHP;

        CalculateLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IfDeadDie();
    }

    void IfDeadDie()
    {
        if (enemyHP <= 0)
        {
            ////gold
            //GameObject enemyDroppedGold = Instantiate(deathDropGold, deathDropPoint.position, Quaternion.identity);
            //enemyDeathDrop DeathDropGoldScript = enemyDroppedGold.GetComponent<enemyDeathDrop>();

            //if (DeathDropGoldScript != null)
            //{
            //    DeathDropGoldScript.SetEnemyScriptReference(this);
            //    DeathDropGoldScript.DetermineAmountGold(DroppedGold);
            //}

            //wood
            GameObject enemyDroppedWood = Instantiate(deathDropWood, deathDropPoint.position, Quaternion.identity);
            enemyDeathDrop DeathDropWoodScript = enemyDroppedWood.GetComponent<enemyDeathDrop>();

            if (DeathDropWoodScript != null)
            {
                DeathDropWoodScript.SetEnemyScriptReference(this);
                DeathDropWoodScript.DetermineAmountWood(DroppedWood);
            }

            //stone
            GameObject enemyDroppedStone = Instantiate(deathDropStone, deathDropPoint.position, Quaternion.identity);
            enemyDeathDrop DeathDropStoneScript = enemyDroppedStone.GetComponent<enemyDeathDrop>();

            if (DeathDropStoneScript != null)
            {
                DeathDropStoneScript.SetEnemyScriptReference(this);
                DeathDropStoneScript.DetermineAmountStone(DroppedStone);
            }

            //steel
            GameObject enemyDroppedSteel = Instantiate(deathDropSteel, deathDropPoint.position, Quaternion.identity);
            enemyDeathDrop DeathDropSteelScript = enemyDroppedSteel.GetComponent<enemyDeathDrop>();

            if (DeathDropSteelScript != null)
            {
                DeathDropSteelScript.SetEnemyScriptReference(this);
                DeathDropSteelScript.DetermineAmountSteel(DroppedSteel);
            }

            Destroy(gameObject);
        }
    }

    void CalculateLevel()
    {
        Encampment.TryGetComponent<enemyEncampment>(out enemyEncampment enemyLvl);
        //enemyLvl.enemyLevel
        if (enemyLvl.enemyLevel == 1)
        {
            enemyMaxHP = 50f; //5X (1) weapon Dps
            enemyHP = 50f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(12.0f, 25.0f);
            DroppedStone = UnityEngine.Random.Range(12.0f, 25.0f);
            DroppedSteel = UnityEngine.Random.Range(3.0f, 16.0f);
        }
        else if (enemyLvl.enemyLevel == 2)
        {
            enemyMaxHP = 100f; //5X (1) weapon Dps
            enemyHP = 100f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(30.0f, 43.0f);
            DroppedStone = UnityEngine.Random.Range(30.0f, 43.0f);
            DroppedSteel = UnityEngine.Random.Range(12.0f, 25.0f);
        }
        else if (enemyLvl.enemyLevel == 3)
        {
            enemyMaxHP = 200f; //5X (1) weapon Dps
            enemyHP = 200f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(66.0f, 79.0f);
            DroppedStone = UnityEngine.Random.Range(66.0f, 79.0f);
            DroppedSteel = UnityEngine.Random.Range(30.0f, 43.0f);
        }
        else if (enemyLvl.enemyLevel == 4)
        {
            enemyMaxHP = 400f; //5X (1) weapon Dps
            enemyHP = 400f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(138.0f, 151.0f);
            DroppedStone = UnityEngine.Random.Range(138.0f, 151.0f);
            DroppedSteel = UnityEngine.Random.Range(66.0f, 79.0f);
        }
        else if (enemyLvl.enemyLevel >= 5)
        {
            enemyMaxHP = 800f; //5X (1) weapon Dps
            enemyHP = 800f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(282.0f, 295.0f);
            DroppedStone = UnityEngine.Random.Range(282.0f, 295.0f);
            DroppedSteel = UnityEngine.Random.Range(138.0f, 151.0f);
        }
    }

    public void DamageDealt(float damageAmount)
    {
        enemyHP -= damageAmount;
        Encampment.TryGetComponent<enemyEncampment>(out enemyEncampment damageTaken);
        damageTaken.EncampmentDamaged();
    }

    public void ProcentDamageDealt(float damageAmount)
    {
        enemyHP -= enemyMaxHP * damageAmount;
        Encampment.TryGetComponent<enemyEncampment>(out enemyEncampment damageTaken);
        damageTaken.EncampmentDamaged();
    }
}
