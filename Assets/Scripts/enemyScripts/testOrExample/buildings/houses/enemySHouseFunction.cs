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
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;
    //health
    private float enemyHP, enemyMaxHP = 50f;

    //death drop
    public GameObject deathDropGold;
    public GameObject deathDropWood;
    public GameObject deathDropStone;
    public GameObject deathDropSteel;

    private float DroppedGold = 0;
    private float DroppedWood = 12;
    private float DroppedStone = 12;
    private float DroppedSteel = 11.52f;

    public Transform deathDropPoint;

    //spreat out from other enemies
    private GameObject[] enemies;
    private Transform closestEnemy;

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
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        enemyHP = enemyMaxHP;

        CalculateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        FindClosestEnemies(); //locate closest enemy
        IfDeadDie();
    }

    void FindClosestEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        closestEnemy = GetClosestEnemy(enemies);
    }

    Transform GetClosestEnemy(GameObject[] enemiesArray)
    {
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemiesArray)
        {
            if (enemy != gameObject)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy.transform;
                }
            }
        }

        return closestEnemy;
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
