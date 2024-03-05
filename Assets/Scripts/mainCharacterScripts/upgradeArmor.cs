using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeArmor : MonoBehaviour
{
    //upgrade armor
    //health
    public static int healthLevel = 1;
    public static bool healthHeavyTank = false;
    public static bool healthLightTank = false;

    public static float maxHealth;

    //armor
    public static int shieldLevel = 0;
    public static bool shieldHeavyArmor = false;
    public static bool shieldLightArmor = false;

    public static float maxShieldHealth = 0f;

    //self repair
    public static int selfRepairLevel = 0;
    public static bool selfRepairHeavyRepair = false;
    public static bool selfRepairLightRepair = false;

    public static float repairCompensation = 0.25f; //how much you can repair of every single point of damage (x100 to get procent)
    public static float repairTime = 2.5f; //the higher the faster
    public static float resourceUsage = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        HealthStart();
        ShieldStart();
        SelfRepairStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region start
    void HealthStart()
    {
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
            maxHealth = 400f;

            if (healthHeavyTank == true)
            {

            }
            if (healthLightTank == true)
            {

            }
        }
        else if (healthLevel == 5)
        {
            maxHealth = 500f;

            if (healthHeavyTank == true)
            {

            }
            if (healthLightTank == true)
            {

            }
        }
    }

    void ShieldStart()
    {
        if (shieldLevel == 1)
        {
            maxShieldHealth = 25f;
        }
        else if (shieldLevel == 2)
        {
            maxShieldHealth = 50f;
        }
        else if (shieldLevel == 3)
        {
            maxShieldHealth = 75f;
        }
        else if (shieldLevel == 4)
        {
            maxShieldHealth = 100f;

            if (shieldHeavyArmor == true)
            {

            }
            if (shieldLightArmor == true)
            {

            }
        }
        else if (shieldLevel == 5)
        {
            maxShieldHealth = 125f;

            if (shieldHeavyArmor == true)
            {

            }
            if (shieldLightArmor == true)
            {

            }
        }
    }

    void SelfRepairStart()
    {
        if (selfRepairLevel == 1)
        {
            repairCompensation = 0.20f;
            repairTime = 2.5f;
        }
        else if (selfRepairLevel == 2)
        {
            repairCompensation = 0.25f;
            repairTime = 4.375f;
        }
        else if (selfRepairLevel == 3)
        {
            repairCompensation = 0.30f;
            repairTime = 6.25f;
        }
        else if (selfRepairLevel == 4)
        {
            repairCompensation = 0.35f;
            repairTime = 8.125f;

            if (selfRepairHeavyRepair == true)
            {

            }
            if (selfRepairLightRepair == true)
            {

            }
        }
        else if (selfRepairLevel == 5)
        {
            repairCompensation = 0.40f;
            repairTime = 10f;

            if (selfRepairHeavyRepair == true)
            {

            }
            if (selfRepairLightRepair == true)
            {

            }
        }
    }
    #endregion

    #region update

    #endregion
}
