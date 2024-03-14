using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeWeapons : MonoBehaviour
{
    //weapon upgrades
    //archers
    public static int bowLevel = 1;
    public static bool ballista = true; //strong, slow reload shot (goes through enemies)
    public static bool hwacha = false; //lots of arrows

    public static float canFireArchers = 0.2f;
    public static float damageAmountArrows = 1;
    public static float arrowSpeed = 7.5f;
    public static float arrowHeightNum = 1f;

    //cannons
    public static int culverinLevel = 0;
    public static bool bombard = false; //big, slow reload shot (explodes on inpact dealing massive damage to 1 target)
    public static bool falconet = false; //grape shot explode on inpact

    public static float canFireCannons = 2;
    public static float damageAmountRound = 5;
    public static float roundSpeed = 12.5f;
    public static float roundHeightNum = 0.5f;

    //catapult
    public static int onagerLevel = 0;
    public static bool trebuchet = false; //big ark (hard to hit) strong payload
    public static bool mangonel = false; //fast reload 

    public static float canFireCatapult = 3;
    public static float damageAmountPayload = 10;
    public static float payloadSpeed = 10f;
    public static float payloadHeightNum = 3f;

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

    #region Upgrades
    void ArchersUpgrades()
    {
        if (bowLevel == 1) //8.333 dps
        {
            canFireArchers = 0.6f;
            damageAmountArrows = 6f;
        }
        else if (bowLevel == 2) //20 dps (+140% dps)
        {
            canFireArchers = 0.5f;
            damageAmountArrows = 10f;
        }
        else if (bowLevel == 3) //37.5 dps (+87.5% dps)
        {
            canFireArchers = 0.4f;
            damageAmountArrows = 16f;
        }
        else if (bowLevel == 4) //66,667 dps (+77.778% dps)
        {
            canFireArchers = 0.3f;
            damageAmountArrows = 24f;

            if (ballista == true)
            {
                //canFireArchers = 0.6f;
                //damageAmountArrows = 10f;
                arrowSpeed = 10f;
                arrowHeightNum = 0.5f;
            }
            if (hwacha == true)
            {

            }
        }
        else if (bowLevel == 5) //125 dps (+87.5 dps)
        {
            canFireArchers = 0.2f;
            damageAmountArrows = 32f;

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
            damageAmountRound = 30f;
        }
        else if (culverinLevel == 2)
        {
            canFireCannons = 2.5f;
            damageAmountRound = 50f;
        }
        else if (culverinLevel == 3)
        {
            canFireCannons = 2f;
            damageAmountRound = 80f;
        }
        else if (culverinLevel == 4)
        {
            canFireCannons = 1.5f;
            damageAmountRound = 120f;

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
            damageAmountRound = 160f;

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
            damageAmountPayload = 40f;
        }
        else if (onagerLevel == 2)
        {
            canFireCatapult = 3.5f;
            damageAmountPayload = 70f;
        }
        else if (onagerLevel == 3)
        {
            canFireCatapult = 3f;
            damageAmountPayload = 120f;
        }
        else if (onagerLevel == 4)
        {
            canFireCatapult = 2.5f;
            damageAmountPayload = 200f;

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
            damageAmountPayload = 320f;

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
