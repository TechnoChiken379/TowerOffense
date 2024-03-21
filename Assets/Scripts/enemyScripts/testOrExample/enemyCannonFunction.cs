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
    private float enemyHP, enemyMaxHP = 25f;

    //attack
    private float attackTimer;
    private float canAttack = 1.5f;

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    //death drop
    public GameObject deathDrop;
    public Transform deathDropPoint;

    //spreat out from other enemies
    private GameObject[] enemies;
    private Transform closestEnemy;

    //turn around
    public GameObject cannon;


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
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        FindClosestEnemies(); //locate closest enemy
        SpreadOut();
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
    public void SpreadOut()
    {
        if (closestEnemy != null && Vector3.Distance(closestEnemy.position, transform.position) < 1f)
        {
            //Vector3 directionToEnemy = (transform.position - closestEnemy.position).normalized;
            //transform.Translate(directionToEnemy * Time.deltaTime * speed);
        }
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
    public void Attack()
    {
        if (attackTimer >= canAttack)
        {
            GameObject enemySpawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            enemyCannonRound projectileScript = enemySpawnedBullet.GetComponent<enemyCannonRound>();

            if (projectileScript != null)
            {
                projectileScript.SetEnemyScriptReference(this);
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
            GameObject enemyDroppedResources = Instantiate(deathDrop, deathDropPoint.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
 
    public void DamageDealt(float damageAmount)
    {
        enemyHP -= damageAmount;
    }

    public void ProcentDamageDealt(float damageAmount)
    {
        enemyHP -= enemyMaxHP * damageAmount;
    }
}
