using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFunction : MonoBehaviour
{
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;
    private float engageDistance = 15f; //at what distance should the enemy start going to the player

    //defence
    //health
    private float enemyHP, enemyMaxHP = 14400f;
    //private float enemySP, enemyMaxSP = 4800f;

    //offense
    //attack
    //arrows
    public static float attackDamageArrows = 20f; //20 dps
    public static float canAttackArrows = 1.5f;

    public static float arrowSpeed = 7.5f;
    public static float arrowHeightNum = 1f;

    //Hwacha
    public static int hwachaAmountBeforeReload = 60;
    public static float hwachaReloadTime = 1f;

    //cannon
    public static float attackDamageCannonRound = 20f; //20 dps
    public static float canAttackCannonRound = 1.5f;

    public static float roundSpeed = 12.5f;
    public static float roundHeightNum = 0.5f;

    //falconet
    public static int grapeShotAmount = 20;

    public static float damageAmountRoundGrapeShot = 20;
    public static float roundSpeedGrapeShot = 7f;

    //bombard
    public static float damageAmountRoundShrapnel = 30f;

    //catepult
    public static float attackDamageCatapultPayload = 20f; //20 dps
    public static float canAttackCatapultPayload = 1.5f;

    public static float payloadSpeed = 10f;
    public static float payloadHeightNum = 3f;

    //mangonel
    public static int mangonelAmountShot = 3;

    //trebuchet
    public static float trebuchetPayloadDeliveryDamage = 10f; //dps per sec


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
        StateConditions(); //check what should the enemy should want to do
        IfDeadDie();
        CalculateLevel();
    }

    public void StateConditions()
    {
        if (distanceToPlayer <= engageDistance) { upgradeArmor.canRegenerating = false; upgradeArmor.leftCombat = 0f; };
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
        //24 dps per weapon
        //arrows
        if (upgradeWeapons.ballista) //boss hwacha
        {
            attackDamageArrows = 18.7f;
            canAttackArrows = 0.1f;

            arrowSpeed = 7f;
            arrowHeightNum = 1f;

            hwachaAmountBeforeReload = 60;
            hwachaReloadTime = 1f;
        }
        else if (upgradeWeapons.hwacha) //boss abllista
        {
            attackDamageArrows = 96f;
            canAttackArrows = 0.6f;

            arrowSpeed = 10f;
            arrowHeightNum = 0.5f;
        }
        else //neither
        {
            attackDamageArrows = 32f;
            canAttackArrows = 0.2f;

            arrowSpeed = 7.5f;
            arrowHeightNum = 1f;
        }
        //cannon
        if (upgradeWeapons.bombard) //boss falconet
        {
            attackDamageCannonRound = 80f;
            canAttackCannonRound = 1f;

            roundSpeed = 12.5f;
            roundHeightNum = 0.5f;

            //grape shot
            grapeShotAmount = 20;

            damageAmountRoundGrapeShot = 12f;
            roundSpeedGrapeShot = 10f;
        }
        else if (upgradeWeapons.falconet) //boss bombard
        {
            attackDamageCannonRound = 270f;
            canAttackCannonRound = 2.25f;

            roundSpeed = 12.5f;
            roundHeightNum = 0.5f;

            //shrarpnel
            damageAmountRoundShrapnel = upgradeArmor.maxHealth * 0.1125f;
        }
        else //neither
        {
            attackDamageCannonRound = 160f;
            canAttackCannonRound = 1f;

            roundSpeed = 12.5f;
            roundHeightNum = 0.5f;
        }
        //catapult
        if (upgradeWeapons.trebuchet) //boss mangonel
        {
            attackDamageCatapultPayload = 133.3f;
            canAttackCatapultPayload = 2f;

            payloadSpeed = 10f;
            payloadHeightNum = 2f;

            mangonelAmountShot = 3;
        }
        if (upgradeWeapons.mangonel) //boss trebuchet
        {
            attackDamageCatapultPayload = 480f;
            canAttackCatapultPayload = 3f;

            payloadSpeed = 10f;
            payloadHeightNum = 6f;

            trebuchetPayloadDeliveryDamage = 120f;
        }
        else //neither
        {
            attackDamageCatapultPayload = 320f;
            canAttackCatapultPayload = 2f;

            payloadSpeed = 10f;
            payloadHeightNum = 3f;
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
