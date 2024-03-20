using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class enemyFunction : MonoBehaviour
{
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;

    private float speed = 3.5f; //movement speed

    private float closeEnough = 5f; //how close does the enemy want to get
    private float optimalDistance = 3f;
    private float toClose = 2f; //how far does the enemy want to stay away from player

    private float timer = 0f; //timer to keep track of time before moving
    private float moveTime = 0.1f; //time to start moving

    private float engageDistance = 10f; //at what distance should the enemy start going to the player

    //health
    private float enemyHP, enemyMaxHP = 25f;

    //attack
    private float attackTimer;
    private float canAttack = 0.5f;

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    //death drop
    public GameObject deathDrop;
    public Transform deathDropPoint;

    //spreat out from other enemies
    private GameObject[] enemies;
    private Transform closestEnemy;

    //animation
    public GameObject standing;
    public GameObject walking;
    private float switchTimer;
    private float switchTime = 0.1f;

    //turn around
    private float angle;
    private float signedAngle;

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

        standing.SetActive(true);
        walking.SetActive(false);
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
            if (distanceToPlayer >= closeEnough) //move to the player if far away
            {
                state = "State.Move";
            }
            else if (distanceToPlayer <= toClose) //move away from player if to close
            {
                state = "State.Retreat";
            }
            else //reset move time if within range to attack player
            {
                timer = 0f;
            }

            if (distanceToPlayer < closeEnough && distanceToPlayer > toClose) //attack player if within the right range to do so
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
                Stand();
                break;
            case "State.attack":
                Attack();
                switchTime = 0.2f;
                if (distanceToPlayer - optimalDistance > 0.05f)
                {
                    Walk();
                }
                else
                {
                    Stand();
                }
                break;
            case "State.Move":
                Move();
                switchTime = 0.1f;
                Walk();
                break;
            case "State.Retreat":
                Retreat();
                switchTime = 0.1f;
                Walk();
                break;
            default: 
                
            break;
        }
    }

    public void Move()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
        }
    }
    public void Retreat()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * -speed);
        }
    }
    public void SpreadOut()
    {
        if (closestEnemy != null && Vector3.Distance(closestEnemy.position, transform.position) < 1f)
        {
            Vector3 directionToEnemy = (transform.position - closestEnemy.position).normalized;
            transform.Translate(directionToEnemy * Time.deltaTime * speed);
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
        if (distanceToPlayer > optimalDistance && optimalDistance - distanceToPlayer < 0.05f)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * (speed * 0.5f));
        }
        if (distanceToPlayer < optimalDistance && distanceToPlayer - optimalDistance < 0.05f)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * -(speed * 0.5f));
        }
        if (attackTimer >= canAttack)
        {
            GameObject enemySpawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            enemyProjectile projectileScript = enemySpawnedBullet.GetComponent<enemyProjectile>();

            if (projectileScript != null)
            {
                projectileScript.SetEnemyScriptReference(this);
            }

            attackTimer = 0f;
        }
    }

    //animations
    void Walk()
    {
        switchTimer += Time.deltaTime;

        if (standing.activeSelf && switchTimer >= switchTime)
        {
            standing.SetActive(false);
            walking.SetActive(true);
            switchTimer = 0f;
        } else if (walking.activeSelf && switchTimer >= switchTime)
        {
            standing.SetActive(true);
            walking.SetActive(false);
            switchTimer = 0f;
        }
    }
    void Stand()
    {
        standing.SetActive(true);
        walking.SetActive(false);
    }

    void TurnAround()
    {
        Vector2 direction = player.transform.position - transform.position;
        angle = Vector2.Angle(Vector2.right, direction);

        signedAngle = Vector2.SignedAngle(Vector2.right, direction);

        if (signedAngle < 0)
        {
            signedAngle += 360;
        }
        if (signedAngle > 90 && signedAngle <= 270)
        {
            standing.transform.localScale = new Vector3(7, 4.5f, 1);
            walking.transform.localScale = new Vector3(7, 4.5f, 1);
        }
        else
        {
            standing.transform.localScale = new Vector3(-7, 4.5f, 1);
            walking.transform.localScale = new Vector3(-7, 4.5f, 1);
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            resources.woodAmount += 35;
            resources.stoneAmount += 35;
            resources.steelAmount += 35;
            resources.goldAmount += 1;

            Destroy(gameObject);
        }
    }
}
