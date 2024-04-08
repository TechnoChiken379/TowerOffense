using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeArmor : MonoBehaviour, IDataPersistance
{
    //upgrade armor
    //health
    public static int healthLevel;
    public static bool healthHeavyTank = true;
    public static bool healthLightTank = false;

    public static float maxHealth;

    public static bool canRegenerating = false;
    public static float leftCombat = 0f;
    private float startRegenerating = 5f;
    private float regeneratingTime = 2.5f;

    public static bool deflectDamage = false;
    public static float deflectDamageNotTaken = 1f;

    //armor
    public static int shieldLevel;
    public static bool shieldHeavyArmor = false;
    public static bool shieldLightArmor = true;

    public static float maxShieldHealth = 0f;

    public static bool ricochet = false;
    public static float ricochetDamageLimit = 10f;
    public static int ricochetchange = 50; //chance to make a round ricochet in procent


    //self repair
    public static int selfRepairLevel;
    public static bool selfRepairHeavyRepair = false;
    public static bool selfRepairLightRepair = true;

    public static float repairCompensation = 0f; //how much you can repair of every single point of damage (x100 to get procent)
    public static float repairTime = 0; //the higher the faster
    public static float repairTimeBase = 2.5f;
    public static float resourceUsage = 20.0f;

    public static bool moveWhileRepairing = false;
    public static bool shootWhileRepairing = false;

    public void LoadData(GameData data)
    {
        healthLevel = data.healthLevel;
        healthHeavyTank = data.heavyTank;
        healthLightTank = data.lightTank;

        shieldLevel = data.shieldLevel;
        shieldHeavyArmor = data.heavyShield;
        shieldLightArmor = data.lightShield;

        selfRepairLevel = data.repairLevel;
        selfRepairHeavyRepair = data.heavyRepair;
        selfRepairLightRepair = data.lightRepair;
}

    public void SaveData(ref GameData data)
    {
        data.healthLevel = healthLevel;
        data.heavyTank = healthHeavyTank;
        data.lightTank = healthLightTank;
            
        data.shieldLevel = shieldLevel;
        data.heavyShield = shieldHeavyArmor;
        data.lightShield = shieldLightArmor;

        data.repairLevel = selfRepairLevel;
        data.heavyRepair = selfRepairHeavyRepair;
        data.lightRepair = selfRepairLightRepair;
    }

    void Start()
    {
        healthLevel = 5;
        shieldLevel = 5;
        selfRepairLevel = 5;

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

            if (healthHeavyTank == true) //active health 500
            {
                maxHealth = 400f;
                deflectDamage = true;
                deflectDamageNotTaken = 0.8f;
            }
            if (healthLightTank == true) //active health 200
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

            if (healthHeavyTank == true) //active health 625
            {
                maxHealth = 500f;
                deflectDamage = true;
                deflectDamageNotTaken = 0.8f;
            }
            if (healthLightTank == true) //active health 250
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

            if (shieldHeavyArmor == true) //active shield 200 
            {
                maxShieldHealth = 200f;

                if (mainCharacter.shieldDamageTakenVariable != 1f || mainCharacter.HealthDamageTakenShieldUp != 0f || mainCharacter.HealthDamageTakenShieldBrake != 1f)
                {
                    mainCharacter.shieldDamageTakenVariable = 1f;
                    mainCharacter.HealthDamageTakenShieldUp = 0f;
                    mainCharacter.HealthDamageTakenShieldBrake = 1f;
                }
            }
            if (shieldLightArmor == true) //active shield 685.7 (assuming all damage taken >= 20, else 480) (25%(/342.9) of incoming damage taken by health)
            {
                maxShieldHealth = 240f;

                ricochet = true;
                ricochetDamageLimit = 20f;
                ricochetchange = 30;
}
        }
        else if (shieldLevel == 5)
        {
            //maxShieldHealth = 250f;

            if (shieldHeavyArmor == true) //active shield 333.3
            {
                maxShieldHealth = 250f;

                if (mainCharacter.shieldDamageTakenVariable != 0.75f || mainCharacter.HealthDamageTakenShieldUp != 0f || mainCharacter.HealthDamageTakenShieldBrake != 1f) 
                {
                    mainCharacter.shieldDamageTakenVariable = 0.75f;
                    mainCharacter.HealthDamageTakenShieldUp = 0f;
                    mainCharacter.HealthDamageTakenShieldBrake = 0.75f;
                }
            }
            if (shieldLightArmor == true) //active shield 750 (assuming all damage taken >= 25, else 600) (25% of incoming damage taken by health)
            {
                maxShieldHealth = 300f;

                ricochet = true;
                ricochetDamageLimit = 25f;
                ricochetchange = 60;
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

                //moveWhileRepairing = false;
                //shootWhileRepairing = true;
}
            if (selfRepairLightRepair == true)
            {
                repairCompensation = 0.35f;
                repairTime = repairTimeBase * 4.875f;

                //moveWhileRepairing = true;
                //shootWhileRepairing = false;
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

                moveWhileRepairing = false;
                shootWhileRepairing = true;
            }
            if (selfRepairLightRepair == true)
            {
                repairCompensation = 0.40f;
                repairTime = repairTimeBase * 6f;

                moveWhileRepairing = true;
                shootWhileRepairing = false;
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
        if (healthLevel > 5)
        {
            healthLevel = 1;
            Debug.Log("Health lvl: " + healthLevel);
        }
        if (shieldLevel > 5)
        {
            shieldLevel = 0;
            Debug.Log("Shield lvl: " + shieldLevel);
        }
        if (selfRepairLevel > 5)
        {
            selfRepairLevel = 0;
            Debug.Log("SelfRepair lvl: " + selfRepairLevel);
        }
    }
}
