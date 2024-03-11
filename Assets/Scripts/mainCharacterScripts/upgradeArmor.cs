using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeArmor : MonoBehaviour
{
    //upgrade armor
    //health
    public static int healthLevel = 1;
    public static bool healthHeavyTank = false;
    public static bool healthLightTank = true;

    public static float maxHealth;

    public static bool canRegenerating = false;
    public static float leftCombat = 0f;
    private float startRegenerating = 5f;
    private float regeneratingTime = 2.5f;

    //armor
    public static int shieldLevel = 0;
    public static bool shieldHeavyArmor = false;
    public static bool shieldLightArmor = true;

    public static float maxShieldHealth = 0f;

    //self repair
    public static int selfRepairLevel = 0;
    public static bool selfRepairHeavyRepair = false;
    public static bool selfRepairLightRepair = true;

    public static float repairCompensation = 0.2f; //how much you can repair of every single point of damage (x100 to get procent)
    public static float repairTime = 0; //the higher the faster
    public static float repairTimeBase = 2.5f;
    public static float resourceUsage = 0.1f;

    void Start()
    {
        HealthUpgrades();
        ShieldUpgrades();
        SelfRepairUpgrades();
    }

    void Update()
    {
        HealthUpgrades();
        ShieldUpgrades();
        SelfRepairUpgrades();

        LevelUp(); //for testing
    }
    #region Upgrades
    void HealthUpgrades()
    {
        //
        leftCombat += Time.deltaTime;

        //
        if (healthLevel == 1) 
        {
            maxHealth = 100f;
        } 
        else if (healthLevel == 2)
        {
            maxHealth = 200f;
        }
        else if (healthLevel == 3)
        {
            maxHealth = 300f;
        }
        else if (healthLevel == 4)
        {
            //maxHealth = 400f;

            if (healthHeavyTank == true)
            {
                maxHealth = 600f;
            }
            if (healthLightTank == true)
            {
                maxHealth = 200f;
                if (canRegenerating && leftCombat >= startRegenerating)
                {
                    mainCharacter.totalCurrentHealth = Mathf.MoveTowards(mainCharacter.totalCurrentHealth, maxHealth, regeneratingTime * Time.deltaTime);
                }
                canRegenerating = true;
            }
        }
        else if (healthLevel == 5)
        {
            //maxHealth = 500f;

            if (healthHeavyTank == true)
            {
                maxHealth = 750f;
            }
            if (healthLightTank == true)
            {
                maxHealth = 250f;
                if (canRegenerating && leftCombat >= startRegenerating)
                {
                    mainCharacter.totalCurrentHealth = Mathf.MoveTowards(mainCharacter.totalCurrentHealth, maxHealth, regeneratingTime * 2 * Time.deltaTime);
                }
                canRegenerating = true;
            }
        }
    }

    void ShieldUpgrades()
    {
        //

        //
        if (shieldLevel == 1)
        {
            maxShieldHealth = 50f;
        }
        else if (shieldLevel == 2)
        {
            maxShieldHealth = 100f;
        }
        else if (shieldLevel == 3)
        {
            maxShieldHealth = 150f;
        }
        else if (shieldLevel == 4)
        {
            //maxShieldHealth = 200f;

            if (shieldHeavyArmor == true)
            {
                maxShieldHealth = 200f;
            }
            if (shieldLightArmor == true)
            {
                maxShieldHealth = 300f;
            }
        }
        else if (shieldLevel == 5)
        {
            //maxShieldHealth = 250f;

            if (shieldHeavyArmor == true)
            {
                maxShieldHealth = 250f;
            }
            if (shieldLightArmor == true)
            {
                maxShieldHealth = 375f;
            }
        }
    }

    void SelfRepairUpgrades()
    {
        //
        repairTimeBase = maxHealth * 0.025f;

        //
        if (selfRepairLevel == 1)
        {
            repairCompensation = 0.20f;
            repairTime = repairTimeBase * 1f;
        }
        else if (selfRepairLevel == 2)
        {
            repairCompensation = 0.25f;
            repairTime = repairTimeBase * 1.75f;
        }
        else if (selfRepairLevel == 3)
        {
            repairCompensation = 0.30f;
            repairTime = repairTimeBase * 2.5f;
        }
        else if (selfRepairLevel == 4)
        {
            //repairCompensation = 0.35f;
            //repairTime = repairTimeBase * 3.25f;

            if (selfRepairHeavyRepair == true)
            {
                repairCompensation = 0.525f;
                repairTime = repairTimeBase * 3.25f;
            }
            if (selfRepairLightRepair == true)
            {
                repairCompensation = 0.35f;
                repairTime = repairTimeBase * 4.875f;
            }
        }
        else if (selfRepairLevel == 5)
        {
            //repairCompensation = 0.40f;
            //repairTime = repairTimeBase * 4f;

            if (selfRepairHeavyRepair == true)
            {
                repairCompensation = 0.60f;
                repairTime = repairTimeBase * 4f;
            }
            if (selfRepairLightRepair == true)
            {
                repairCompensation = 0.40f;
                repairTime = repairTimeBase * 6f;
            }
        }
    }
    #endregion

    void LevelUp()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            healthLevel++;
            Debug.Log("Health lvl: " + healthLevel);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            shieldLevel++;
            Debug.Log("Shield lvl: " + shieldLevel);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selfRepairLevel++;
            Debug.Log("SelfRepair lvl: " + selfRepairLevel);
        }
    }
}
