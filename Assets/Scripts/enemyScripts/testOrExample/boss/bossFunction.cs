using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFunction : MonoBehaviour
{
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;
    private float closeEnough = 15f; //how close does the enemy want to get

    private float engageDistance = 15f; //at what distance should the enemy start going to the player

    //defence
    //health
    private float enemyHP, enemyMaxHP = 1440f;
    //private float enemySP, enemyMaxSP = 720f;

    //offense
    //attack
    //arrows
    private float attackDamageArrows = 20f; //20 dps
    private float canAttackArrows = 1.5f;

    private float arrowSpeed = 7.5f;
    private float arrowHeightNum = 1f;

    //cannon
    private float attackDamageCannonRound = 20f; //20 dps
    private float canAttackCannonRound = 1.5f;

    private float roundSpeed = 12.5f;
    private float roundHeightNum = 0.5f;

    //catepult
    private float attackDamageCatapultPayload = 20f; //20 dps
    private float canAttackCatapultPayload = 1.5f;

    private float payloadSpeed = 10f;
    private float payloadHeightNum = 3f;

    //weapontimers
    private float attackTimerArrows;
    private float attackTimerCannonRound;
    private float attackTimerCatapultPayload;


    public GameObject bullet;
    public Transform bulletSpawnPoint;

    //death drop
    public GameObject deathDropGold;
    public GameObject deathDropWood;
    public GameObject deathDropStone;
    public GameObject deathDropSteel;

    private float DroppedGold = 100;
    private float DroppedWood = 1000;
    private float DroppedStone = 1000;
    private float DroppedSteel = 1000;

    public Transform deathDropPoint;

    //spreat out from other enemies
    private GameObject[] enemies;
    private Transform closestEnemy;


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
        SpreadOut();
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
                //attackTimer += Time.deltaTime;
            }
        }
        else //idle if the enemy is out of range of the player
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
        if (closestEnemy != null && Vector2.Distance(closestEnemy.position, transform.position) < 1f)
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
        //if (attackTimer >= canAttack)
        //{
        //    GameObject enemySpawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        //    enemyCannonProjectile projectileScript = enemySpawnedBullet.GetComponent<enemyCannonProjectile>();

        //    if (projectileScript != null)
        //    {
        //        projectileScript.SetEnemyScriptReference(this);
        //        projectileScript.DetermineDamage(attackDamage);
        //    }

        //    attackTimer = 0f;
        //}
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
    void CalculateLevel()
    {
        attackDamageArrows = 20;
        attackDamageCannonRound = 20;
        attackDamageCatapultPayload = 20;
        //canAttack = 1f;

        DroppedWood = UnityEngine.Random.Range(900.0f, 1100.0f);
        DroppedStone = UnityEngine.Random.Range(900.0f, 1100.0f);
        DroppedSteel = UnityEngine.Random.Range(900.0f, 1100.0f);
        DroppedGold = UnityEngine.Random.Range(90.0f, 110.0f);

        #region armor
        //if (upgradeArmor.healthHeavyTank)
        //{
        //    enemyMaxHP = 1440f;
        //    enemyHP = 1440f;
        //}
        //if (upgradeArmor.healthLightTank)
        //{
        //    enemyMaxHP = 720f;
        //    enemyHP = 720f;
        //}
        //if (upgradeArmor.shieldHeavyArmor)
        //{
        //    enemyMaxSP = 720f;
        //    enemySP = 720f;
        //}
        //if (upgradeArmor.shieldLightArmor)
        //{
        //    enemyMaxSP = 864f;
        //    enemySP = 864f;
        //}
        //if (upgradeArmor.selfRepairHeavyRepair)
        //{

        //}
        //if (upgradeArmor.selfRepairLightRepair)
        //{

        //}
        #endregion
        #region weapons
        //arrows
        if (upgradeWeapons.ballista) //boss hwacha
        {
            attackDamageArrows = 20f;
            canAttackArrows = 1.5f;
        }
        else if (upgradeWeapons.hwacha) //boss abllista
        {
            attackDamageArrows = 20f;
            canAttackArrows = 1.5f;
        }
        else //neither
        {
            attackDamageArrows = 20f;
            canAttackArrows = 1.5f;
        }
        //cannon
        if (upgradeWeapons.bombard) //boss falconet
        {
            attackDamageCannonRound = 20f;
            canAttackCannonRound = 1.5f;
        }
        else if (upgradeWeapons.falconet) //boss bombard
        {
            attackDamageCannonRound = 20f;
            canAttackCannonRound = 1.5f;
        }
        else //neither
        {
            attackDamageCannonRound = 20f;
            canAttackCannonRound = 1.5f;
        }
        //catapult
        if (upgradeWeapons.trebuchet) //boss mangonel
        {
            attackDamageCatapultPayload = 20f;
            canAttackCatapultPayload = 1.5f;
        }
        if (upgradeWeapons.mangonel) //boss trebuchet
        {
            attackDamageCatapultPayload = 20f;
            canAttackCatapultPayload = 1.5f;
        }
        else //neither
        {
            attackDamageCatapultPayload = 20f;
            canAttackCatapultPayload = 1.5f;
        }
        #endregion
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
