using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeWeapons : MonoBehaviour
{
    //weapon upgrades
    //archers
    public static int bowLevel = 1;
    public static bool ballista = false;
    public static bool hwacha = false;

    public static float canFireArchers = 0.2f;
    public static float damageAmountArrows = 1;

    //cannons
    public static int culverinLevel = 0;
    public static bool bombard = false;
    public static bool falconet = false;

    public static float canFireCannons = 2;
    public static float damageAmountRound = 5;

    //catapult
    public static int onagerLevel = 0;
    public static bool trebuchet = false;
    public static bool mangonel = false;

    public static float canFireCatapult = 3;
    public static float damageAmountPayload = 10;

    // Start is called before the first frame update
    void Start()
    {
        ArchersUpgrades();
        CannonsUpgrades();
        CatapultUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        ArchersUpgrades();
        CannonsUpgrades();
        CatapultUpgrades();

        LevelUp(); //for testing
    }

    //lvl1 20 dps
    //lvl2 40 dps
    //lvl3 60 dps
    //lvl4 80 dps
    //lvl5 100 dps

    #region Upgrades
    void ArchersUpgrades()
    {
        if (bowLevel == 1) //8.333 dps
        {
            canFireArchers = 0.6f;
            damageAmountArrows = 5f;
        }
        else if (bowLevel == 2) //20 dps (+140% dps)
        {
            canFireArchers = 0.5f;
            damageAmountArrows = 5f;
        }
        else if (bowLevel == 3) //37.5 dps (+87.5% dps)
        {
            canFireArchers = 0.4f;
            damageAmountArrows = 5f;
        }
        else if (bowLevel == 4) //66,667 dps (+77.778% dps)
        {
            canFireArchers = 0.3f;
            damageAmountArrows = 5f;

            if (ballista == true)
            {

            }
            if (hwacha == true)
            {

            }
        }
        else if (bowLevel == 5) //125 dps (+87.5 dps)
        {
            canFireArchers = 0.2f;
            damageAmountArrows = 5f;

            if (ballista == true)
            {

            }
            if (hwacha == true)
            {

            }
        }
    }

    void CannonsUpgrades()
    {
        if (culverinLevel == 1)
        {
            canFireCannons = 3f;
            damageAmountRound = 15f;
        }
        else if (culverinLevel == 2)
        {
            canFireCannons = 2.5f;
            damageAmountRound = 15f;
        }
        else if (culverinLevel == 3)
        {
            canFireCannons = 2f;
            damageAmountRound = 15f;
        }
        else if (culverinLevel == 4)
        {
            canFireCannons = 1.5f;
            damageAmountRound = 15f;

            if (bombard == true)
            {

            }
            if (falconet == true)
            {

            }
        }
        else if (culverinLevel == 5)
        {
            canFireCannons = 1f;
            damageAmountRound = 15f;

            if (bombard == true)
            {

            }
            if (falconet == true)
            {

            }
        }
    }

    void CatapultUpgrades()
    {
        if (onagerLevel == 1)
        {
            canFireCatapult = 4f;
            damageAmountPayload = 25f;
        }
        else if (onagerLevel == 2)
        {
            canFireCatapult = 3.5f;
            damageAmountPayload = 25f;
        }
        else if (onagerLevel == 3)
        {
            canFireCatapult = 3f;
            damageAmountPayload = 25f;
        }
        else if (onagerLevel == 4)
        {
            canFireCatapult = 2.5f;
            damageAmountPayload = 25f;

            if (trebuchet == true)
            {

            }
            if (mangonel == true)
            {

            }
        }
        else if (onagerLevel == 5)
        {
            canFireCatapult = 2;
            damageAmountPayload = 25f;

            if (trebuchet == true)
            {

            }
            if (mangonel == true)
            {

            }
        }
    }
    #endregion

    void LevelUp()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            bowLevel++;
            Debug.Log("Archer lvl: " + bowLevel);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            culverinLevel++;
            Debug.Log("Cannon lvl: " + culverinLevel);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            onagerLevel++;
            Debug.Log("Catapult lvl: " + onagerLevel);
        }
    }
}
