using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class upgradeWeapons : MonoBehaviour
{
    //weapon upgrades
    //archers
    public static int bowLevel = 1;
    public static bool ballista = false; //strong, slow reload shot (goes through enemies)
    public static bool hwacha = false; //lots of arrows

    public static float canFireArchers = 0.2f;
    public static float damageAmountArrows = 1;
    public static float arrowSpeed = 7.5f;
    public static float arrowHeightNum = 1f;

    //Hwacha
    public static int hwachaAmountBeforeReload = 10;
    public static float hwachaReloadTime = 3f;

    //cannons
    public static int culverinLevel = 0;
    public static bool bombard = false; //?big, slow reload shot (explodes on inpact dealing massive damage to 1 target)
    public static bool falconet = false; //grape shot explode on inpact

    public static float canFireCannons = 2;
    public static float damageAmountRound = 5;
    public static float roundSpeed = 12.5f;
    public static float roundHeightNum = 0.5f;

    //falconet
    public static int grapeShotAmount = 4;

    public static float damageAmountRoundGrapeShot = 5;
    public static float roundSpeedGrapeShot = 7f;

    //bombard
    public static float procentBombardDamage = 0f;

    //catapult
    public static int onagerLevel = 0;
    public static bool trebuchet = false; //big ark (hard to hit) strong payload
    public static bool mangonel = true; //?fast reload 

    public static float canFireCatapult = 3;
    public static float damageAmountPayload = 10;
    public static float payloadSpeed = 10f;
    public static float payloadHeightNum = 3f;

    //mangonel
    public static int mangonelAmountShot = 1;

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

    #region archer
    void ArchersUpgrades()
    {
        if (bowLevel == 1) //10 dps
        {
            canFireArchers = 0.6f;
            damageAmountArrows = 6f;
        }
        else if (bowLevel == 2) //20 dps
        {
            canFireArchers = 0.5f;
            damageAmountArrows = 10f;
        }
        else if (bowLevel == 3) //40 dps
        {
            canFireArchers = 0.4f;
            damageAmountArrows = 16f;
        }
        else if (bowLevel == 4) //80 dps
        {
            //canFireArchers = 0.3f;
            //damageAmountArrows = 24f;

            if (ballista == true)
            {
                canFireArchers = 0.6f;
                damageAmountArrows = 48f;
                arrowSpeed = 10f;
                arrowHeightNum = 0.5f;
            }
            if (hwacha == true)
            {
                canFireArchers = 0.1f;
                damageAmountArrows = 8f;
                arrowSpeed = 7f;
                arrowHeightNum = 1f;

                hwachaAmountBeforeReload = 50;
                hwachaReloadTime = 2f;
            }
        }
        else if (bowLevel == 5) //160 dps
        {
            //canFireArchers = 0.2f;
            //damageAmountArrows = 32f;

            if (ballista == true)
            {
                canFireArchers = 0.6f;
                damageAmountArrows = 96f;
                arrowSpeed = 10f;
                arrowHeightNum = 0.5f;
            }
            if (hwacha == true)
            {
                canFireArchers = 0.1f;
                damageAmountArrows = 16f;
                arrowSpeed = 7f;
                arrowHeightNum = 1f;

                hwachaAmountBeforeReload = 70;
                hwachaReloadTime = 1f;
            }
        }
    }
    #endregion

    #region cannon
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
            //canFireCannons = 1.5f;
            //damageAmountRound = 120f;

            if (bombard == true)
            {
                canFireCannons = 1.5f;
                damageAmountRound = 0f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                procentBombardDamage = 0.1f;
            }
            if (falconet == true)
            {
                canFireCannons = 1.5f;
                damageAmountRound = 60f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                //grape shot
                grapeShotAmount = 8;

                damageAmountRoundGrapeShot = 10;
                roundSpeedGrapeShot = 7f;
}
        }
        else if (culverinLevel == 5)
        {
            //canFireCannons = 1f;
            //damageAmountRound = 160f;

            if (bombard == true)
            {
                canFireCannons = 1.5f;
                damageAmountRound = 0f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                procentBombardDamage = 0.2f;
            }
            if (falconet == true)
            {
                canFireCannons = 1f;
                damageAmountRound = 80f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                //grape shot
                grapeShotAmount = 12;

                damageAmountRoundGrapeShot = 20;
                roundSpeedGrapeShot = 7f;
            }
        }
    }
    #endregion

    #region catapult
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
            //canFireCatapult = 2.5f;
            //damageAmountPayload = 200f;

            if (trebuchet == true)
            {
                canFireCatapult = 2.5f;
                damageAmountPayload = 200f;
                payloadSpeed = 10f;
                payloadHeightNum = 6f;
            }
            if (mangonel == true)
            {
                canFireCatapult = 2.5f;
                damageAmountPayload = 100f;
                payloadSpeed = 10f;
                payloadHeightNum = 2f;

                mangonelAmountShot = 2;
            }
        }
        else if (onagerLevel == 5)
        {
            //canFireCatapult = 2;
            //damageAmountPayload = 320f;

            if (trebuchet == true)
            {
                canFireCatapult = 2f;
                damageAmountPayload = 320f;
                payloadSpeed = 10f;
                payloadHeightNum = 6f;
            }
            if (mangonel == true)
            {
                canFireCatapult = 2f;
                damageAmountPayload = 100f;
                payloadSpeed = 10f;
                payloadHeightNum = 2f;

                mangonelAmountShot = 3;
            }
        }
    }
    #endregion

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
