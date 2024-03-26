using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyRogueFunction : MonoBehaviour
{
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;

    private float generalSpeed = 3.75f; //movement speed
    private float combatSpeed = 4f; //movement speed

    private float closeEnough = 3f; //how close does the enemy want to get
    private float melee = 1.1f;
    private float optimalDistance = 1f;
    private float toClose = 0.9f; //how far does the enemy want to stay away from player

    private float timer = 0f; //timer to keep track of time before moving
    private float moveTime = 0.0f; //time to start moving

    private float engageDistance = 10f; //at what distance should the enemy start going to the player

    //health
    private float enemyHP, enemyMaxHP = 15f;

    //attack
    private float MattackDamage = 5f;
    private float RattackDamage = 2.5f;

    private float attackTimer;
    private float canAttackRanged = 0.5f;
    private float canAttackMelee = 1.0f;

    public GameObject bullet;
    public GameObject bullet2;
    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPoint2;

    //death drop
    public GameObject deathDropGold;
    public GameObject deathDropWood;
    public GameObject deathDropStone;
    public GameObject deathDropSteel;

    private float DroppedGold = 1;
    private float DroppedWood = 10;
    private float DroppedStone = 10;
    private float DroppedSteel = 10;

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

    //encampment
    public GameObject Encampment;
    private float distanceToEncampment;

    private float returnToEncampment = 20f;
    private float returnedToEncampment = 2f;
    private bool returningToEncampment = false;

    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        distanceToEncampment = Vector2.Distance(transform.position, Encampment.transform.position);

        enemyHP = enemyMaxHP;

        standing.SetActive(true);
        walking.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        distanceToEncampment = Vector2.Distance(transform.position, Encampment.transform.position);

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

        if (!returningToEncampment && distanceToPlayer <= engageDistance && distanceToEncampment <= returnToEncampment) //check if the enemy is within range of the player
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
        }
        else if (distanceToPlayer > engageDistance && distanceToEncampment >= returnedToEncampment)
        {
            state = "State.Return";
            returningToEncampment = true;
        }
        else if (distanceToEncampment >= returnedToEncampment)
        {
            state = "State.Return";
            returningToEncampment = true;
        }
        else if (!returningToEncampment)//idle if the enemy is out of range of the player
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
            case "State.Return":
                Return();
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
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * generalSpeed);
        }
    }
    public void Retreat()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * -combatSpeed);
        }
    }
    public void SpreadOut()
    {
        if (closestEnemy != null && Vector3.Distance(closestEnemy.position, transform.position) < 0.75f)
        {
            Vector3 directionToEnemy = (transform.position - closestEnemy.position).normalized;
            transform.Translate(directionToEnemy * Time.deltaTime * generalSpeed);
        }
    }
    public void Return()
    {
        transform.Translate((Encampment.transform.position - transform.position).normalized * Time.deltaTime * generalSpeed);
        if (distanceToEncampment <= returnedToEncampment)
        {
            returningToEncampment = false;
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
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * (combatSpeed * 1f));
        }
        if (distanceToPlayer < optimalDistance && optimalDistance - distanceToPlayer < 0.05f)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * -(combatSpeed * 1f));
        }
        if (attackTimer >= canAttackRanged && distanceToPlayer > melee)
        {
            GameObject enemySpawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            enemyRogueRProjectile projectileScript = enemySpawnedBullet.GetComponent<enemyRogueRProjectile>();

            if (projectileScript != null)
            {
                projectileScript.SetEnemyScriptReference(this);
                projectileScript.DetermineDamage(RattackDamage);
            }

            attackTimer = 0f;
        }
        if (attackTimer >= canAttackMelee && distanceToPlayer <= melee)
        {
            GameObject enemySpawnedBullet = Instantiate(bullet2, bulletSpawnPoint2.position, Quaternion.identity);
            enemyRogueMProjectile projectileScript = enemySpawnedBullet.GetComponent<enemyRogueMProjectile>();

            if (projectileScript != null)
            {
                projectileScript.SetEnemyScriptReference(this);
                projectileScript.DetermineDamage(MattackDamage);
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
        }
        else if (walking.activeSelf && switchTimer >= switchTime)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            resources.woodAmount += DroppedWood;
            resources.stoneAmount += DroppedStone;
            resources.steelAmount += DroppedSteel;
            resources.goldAmount += DroppedGold;

            Destroy(gameObject);
        }
    }
}
