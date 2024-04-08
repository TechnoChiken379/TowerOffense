using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class abilityScript : MonoBehaviour
{
    //idea's
    //arty strike (probably arrow's that rain down on enemies)
    //supply drop (probably for health and shield)
    //overdrive (faster movement and attack speed)

    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    private float abilityTimer;
    private float abilityCoolDown = 60f;

    //artillery strike
    public static int artilleryStrikeAmount = 10;
    private int artilleryStrikeArrowAmountFired = 25;

    public GameObject ArtilleryArrow;
    float spawnDistance = 20f;

    private bool FiredArtillery = false;
    private float shootArtillery = 0.01f;
    private float artilleryTime;
    private int artilleryAmountShot;

    public static float damageAmountArrows = 100;
    public static float arrowSpeed = 20f;
    public static float arrowHeightNum = 7.5f;

    Vector2 playerPosition;
    Vector2 spawn;
    Vector2 spawnPosition;

    //supply drop
    public static int supplyDropAmount = 0;

    public GameObject supplyDrop;
    public static float SupplyDrophight = 15f;
    public static float healthRegenerationSpeed = 10f;
    public static float shieldRegenerationSpeed = 10f;

    public static float supplyDistance = 5f;
    public static float timeAlive = 10f;

    void Start()
    {
        abilityTimer = abilityCoolDown;
    }

    void Update()
    {
        abilityTimer += Time.deltaTime;
        Abilities();
        AbilityStrength();

        #region Artillery
        if (FiredArtillery)
        {
            ShootArtillery();
        }
        #endregion
    }

    public void Abilities()
    {
        if (Input.GetKeyDown(KeyCode.Space) && artilleryStrikeAmount > 0 && abilityTimer >= abilityCoolDown)
        {
            ArtilleryStrike();
            abilityTimer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && supplyDropAmount > 0 && abilityTimer >= abilityCoolDown)
        {
            SupplyDrop();
            abilityTimer = 0f;
        }
    }

    #region ability method's
    public void ArtilleryStrike()
    {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        playerPosition = new Vector2(transform.position.x, transform.position.y);

        spawn = (playerPosition - worldMousePosition).normalized;
        spawnPosition = playerPosition - spawn * -spawnDistance;

        artilleryStrikeAmount--;

        artilleryTime = shootArtillery;
        artilleryAmountShot = 0;
        FiredArtillery = true;
    }
    public void ShootArtillery()
    {
        artilleryTime += Time.deltaTime;

        if (artilleryTime >= shootArtillery)
        {
            GameObject spawnedBullet = Instantiate(ArtilleryArrow, spawnPosition, Quaternion.Euler(0, 0, 0));

            artilleryAmountShot++;
            artilleryTime = 0f;
        }

        if (artilleryAmountShot >= artilleryStrikeArrowAmountFired)
        {
            FiredArtillery = false;
        }
    }

    public void SupplyDrop()
    {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 supplyDropSpawnPosition = new Vector2(worldMousePosition.x, worldMousePosition.y + SupplyDrophight);
        GameObject spawnedBullet = Instantiate(supplyDrop, supplyDropSpawnPosition, Quaternion.Euler(0, 0, 0));
    }
    #endregion

    public void AbilityStrength()
    {
        int totalPlayerOffenseLevel;
        int totalPlayerDefenseLevel;
        int totalPlayerLevel;

        totalPlayerOffenseLevel = upgradeWeapons.bowLevel + upgradeWeapons.culverinLevel + upgradeWeapons.onagerLevel;
        totalPlayerDefenseLevel = upgradeArmor.healthLevel + upgradeArmor.shieldLevel + upgradeArmor.selfRepairLevel;
        totalPlayerLevel = totalPlayerOffenseLevel + totalPlayerDefenseLevel;

        if (totalPlayerLevel < 6) //lvl0
        {
            abilityCoolDown = 55f;
            //arty
            artilleryStrikeArrowAmountFired = 25;
            damageAmountArrows = 15f;
            arrowSpeed = 20f;
            //supps
            healthRegenerationSpeed = upgradeArmor.maxHealth * 0.1f;
            shieldRegenerationSpeed = upgradeArmor.maxShieldHealth * 0.1f;
            supplyDistance = 5f;
            timeAlive = 10f;
        }
        else if (totalPlayerLevel >= 6 && totalPlayerLevel < 12) //lvl1
        {
            abilityCoolDown = 50f;
            //arty
            artilleryStrikeArrowAmountFired = 26;
            damageAmountArrows = 30f;
            arrowSpeed = 20f;
            //supps
            healthRegenerationSpeed = upgradeArmor.maxHealth * 0.11f;
            shieldRegenerationSpeed = upgradeArmor.maxShieldHealth * 0.11f;
            supplyDistance = 6f;
            timeAlive = 11f;
        }
        else if (totalPlayerLevel >= 12 && totalPlayerLevel < 18) //lvl2
        {
            abilityCoolDown = 45f;
            //arty
            artilleryStrikeArrowAmountFired = 27;
            damageAmountArrows = 60f;
            arrowSpeed = 20f;
            //supps
            healthRegenerationSpeed = upgradeArmor.maxHealth * 0.12f;
            shieldRegenerationSpeed = upgradeArmor.maxShieldHealth * 0.12f;
            supplyDistance = 7f;
            timeAlive = 12f;
        }
        else if (totalPlayerLevel >= 18 && totalPlayerLevel < 24) //lvl3
        {
            abilityCoolDown = 40f;
            //arty
            artilleryStrikeArrowAmountFired = 28;
            damageAmountArrows = 120f;
            arrowSpeed = 20f;
            //supps
            healthRegenerationSpeed = upgradeArmor.maxHealth * 0.13f;
            shieldRegenerationSpeed = upgradeArmor.maxShieldHealth * 0.13f;
            supplyDistance = 8f;
            timeAlive = 13f;
        }
        else if (totalPlayerLevel >= 24 && totalPlayerLevel < 30) //lvl4
        {
            abilityCoolDown = 35f;
            //arty
            artilleryStrikeArrowAmountFired = 29;
            damageAmountArrows = 240f;
            arrowSpeed = 20f;
            //supps
            healthRegenerationSpeed = upgradeArmor.maxHealth * 0.14f;
            shieldRegenerationSpeed = upgradeArmor.maxShieldHealth * 0.14f;
            supplyDistance = 9f;
            timeAlive = 14f;
        }
        else if (totalPlayerLevel >= 30 && totalPlayerLevel < 36) //lvl5
        {
            abilityCoolDown = 30f;
            //arty
            artilleryStrikeArrowAmountFired = 30;
            damageAmountArrows = 480f;
            arrowSpeed = 20f;
            //supps
            healthRegenerationSpeed = upgradeArmor.maxHealth * 0.15f;
            shieldRegenerationSpeed = upgradeArmor.maxShieldHealth * 0.15f;
            supplyDistance = 10f;
            timeAlive = 15f;
        }

    }
}
