using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class enemySHouseFunction : MonoBehaviour
{
    //health
    private float enemyHP, enemyMaxHP = 50f;

    //death drop
    public GameObject deathDropGold;
    public GameObject deathDropWood;
    public GameObject deathDropStone;
    public GameObject deathDropSteel;

    //private float DroppedGold = 0;
    private float DroppedWood = 12;
    private float DroppedStone = 12;
    private float DroppedSteel = 11.52f;

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

            DroppedWood = UnityEngine.Random.Range(6.0f, 19.0f);
            DroppedStone = UnityEngine.Random.Range(6.0f, 19.0f);
            DroppedSteel = UnityEngine.Random.Range(5.52f, 18.52f);
        }
        else if (enemyLvl.enemyLevel == 2)
        {
            enemyMaxHP = 100f; //5X (1) weapon Dps
            enemyHP = 100f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(18.0f, 31.0f);
            DroppedStone = UnityEngine.Random.Range(18.0f, 31.0f);
            DroppedSteel = UnityEngine.Random.Range(17.04f, 30.04f);
        }
        else if (enemyLvl.enemyLevel == 3)
        {
            enemyMaxHP = 200f; //5X (1) weapon Dps
            enemyHP = 200f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(42.0f, 55.0f);
            DroppedStone = UnityEngine.Random.Range(42.0f, 55.0f);
            DroppedSteel = UnityEngine.Random.Range(40.08f, 53.08f);
        }
        else if (enemyLvl.enemyLevel == 4)
        {
            enemyMaxHP = 400f; //5X (1) weapon Dps
            enemyHP = 400f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(90.0f, 103.0f);
            DroppedStone = UnityEngine.Random.Range(90.0f, 103.0f);
            DroppedSteel = UnityEngine.Random.Range(86.16f, 99.16f);
        }
        else if (enemyLvl.enemyLevel >= 5)
        {
            enemyMaxHP = 800f; //5X (1) weapon Dps
            enemyHP = 800f; //5X (1) weapon Dps

            DroppedWood = UnityEngine.Random.Range(186.0f, 199.0f);
            DroppedStone = UnityEngine.Random.Range(186.0f, 199.0f);
            DroppedSteel = UnityEngine.Random.Range(178.32f, 191.32f);
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
