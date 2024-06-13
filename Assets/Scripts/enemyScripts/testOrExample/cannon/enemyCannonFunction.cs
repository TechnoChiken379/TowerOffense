using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class enemyCannonFunction : MonoBehaviour
{
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;
    private float closeEnough = 10f; //how close does the enemy want to get

    private float engageDistance = 10f; //at what distance should the enemy start going to the player

    //health
    private float enemyHP, enemyMaxHP = 50f;

    //attack
    private float attackDamage = 20f;

    private float attackTimer;
    private float canAttack = 1.5f;

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    //death drop
    public GameObject deathDropGold;
    public GameObject deathDropWood;
    public GameObject deathDropStone;
    public GameObject deathDropSteel;

    private float DroppedGold = 1;
    private float DroppedWood = 12;
    private float DroppedStone = 12;
    //private float DroppedSteel = 0;

    public Transform deathDropPoint;

    //spreat out from other enemies
    private GameObject[] enemies;
    private Transform closestEnemy;

    //turn around
    public GameObject cannon;

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
        TurnAround();
        StateConditions(); //check what should the enemy should want to do
        ExecuteConditions(); //try to do what the enemy should want to do
        IfDeadDie();
    }

    public void StateConditions()
    {
        if (distanceToPlayer <= engageDistance) { upgradeArmor.canRegenerating = false; upgradeArmor.leftCombat = 0f; };

        if (distanceToPlayer <= engageDistance) //check if the enemy is within range of the player
        {
            if (distanceToPlayer < closeEnough) //attack player if within the right range to do so
            {
                state = "State.attack";
                attackTimer += Time.deltaTime;
            }
        } else //idle if the enemy is out of range of the player
        {
            state = "State.Idle";
        }
    }
    public void ExecuteConditions()
    {
        switch (state)
        {
            case "State.Idle": 
                //do nothing
                break;
            case "State.attack":
                Attack();
                break;
            default: 
                
            break;
        }
    }
    public void Attack()
    {
        if (attackTimer >= canAttack)
        {
            GameObject enemySpawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            enemyCannonProjectile projectileScript = enemySpawnedBullet.GetComponent<enemyCannonProjectile>();

            if (projectileScript != null)
            {
                projectileScript.SetEnemyScriptReference(this);
                projectileScript.DetermineDamage(attackDamage);
            }

            attackTimer = 0f;
        }
    }

    void TurnAround()
    {
        var dir = player.position - cannon.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        cannon.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    void IfDeadDie()
    {
        if (enemyHP <= 0)
        {
            //gold
            GameObject enemyDroppedGold = Instantiate(deathDropGold, deathDropPoint.position, Quaternion.identity);
            enemyDeathDrop DeathDropGoldScript = enemyDroppedGold.GetComponent<enemyDeathDrop>();

            if (DeathDropGoldScript != null)
            {
                DeathDropGoldScript.SetEnemyScriptReference(this);
                DeathDropGoldScript.DetermineAmountGold(DroppedGold);
            }

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

            ////steel
            //GameObject enemyDroppedSteel = Instantiate(deathDropSteel, deathDropPoint.position, Quaternion.identity);
            //enemyDeathDrop DeathDropSteelScript = enemyDroppedSteel.GetComponent<enemyDeathDrop>();

            //if (DeathDropSteelScript != null)
            //{
            //    DeathDropSteelScript.SetEnemyScriptReference(this);
            //    DeathDropSteelScript.DetermineAmountSteel(DroppedSteel);
            //}

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

            attackDamage = 20; //20% van player max HP
            //canAttack = 1f;

            DroppedWood = UnityEngine.Random.Range(6.0f, 19.0f);
            DroppedStone = UnityEngine.Random.Range(6.0f, 19.0f);
            DroppedGold = UnityEngine.Random.Range(1.0f, 3.0f);
        }
        else if (enemyLvl.enemyLevel == 2)
        {
            enemyMaxHP = 100f; //5X (1) weapon Dps
            enemyHP = 100f; //5X (1) weapon Dps

            attackDamage = 40; //20% van player max HP
            //canAttack = 1f;

            DroppedWood = UnityEngine.Random.Range(18.0f, 31.0f);
            DroppedStone = UnityEngine.Random.Range(18.0f, 31.0f);
            DroppedGold = UnityEngine.Random.Range(2.0f, 4.0f);
        }
        else if (enemyLvl.enemyLevel == 3)
        {
            enemyMaxHP = 200f; //5X (1) weapon Dps
            enemyHP = 200f; //5X (1) weapon Dps

            attackDamage = 60; //20% van player max HP
            //canAttack = 1f;

            DroppedWood = UnityEngine.Random.Range(42.0f, 55.0f);
            DroppedStone = UnityEngine.Random.Range(42.0f, 55.0f);
            DroppedGold = UnityEngine.Random.Range(3.0f, 5.0f);
        }
        else if (enemyLvl.enemyLevel == 4)
        {
            enemyMaxHP = 400f; //5X (1) weapon Dps
            enemyHP = 400f; //5X (1) weapon Dps

            attackDamage = 80; //20% van player max HP
            //canAttack = 1f;

            DroppedWood = UnityEngine.Random.Range(90.0f, 103.0f);
            DroppedStone = UnityEngine.Random.Range(90.0f, 103.0f);
            DroppedGold = UnityEngine.Random.Range(4.0f, 6.0f);
        }
        else if (enemyLvl.enemyLevel >= 5)
        {
            enemyMaxHP = 800f; //5X (1) weapon Dps
            enemyHP = 800f; //5X (1) weapon Dps

            attackDamage = 100; //20% van player max HP
            //canAttack = 1f;

            DroppedWood = UnityEngine.Random.Range(186.0f, 199.0f);
            DroppedStone = UnityEngine.Random.Range(186.0f, 199.0f);
            DroppedGold = UnityEngine.Random.Range(5.0f, 7.0f);
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
