using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class upgradeWeapons : MonoBehaviour
{
    //weapon upgrades
    //archers
    public static int bowLevel = 3;
    public static bool ballista = false; //slow firing strong arrow that goes through enemies
    public static bool hwacha = true; //shoots a load of arrow's in quick succession before having to reload for some time

    public static float canFireArchers = 0.2f;
    public static float damageAmountArrows = 1;
    public static float arrowSpeed = 7.5f;
    public static float arrowHeightNum = 1f;

    //Hwacha
    public static int hwachaAmountBeforeReload = 10;
    public static float hwachaReloadTime = 3f;

    //cannons
    public static int culverinLevel = 3;
    public static bool bombard = false; //shoots a big round that will explode on contact (or at the end of it's trajectory) (the explodion deals procentage damage)
    public static bool falconet = true; //shoots grape shot rounds that explode/scatter on contact (or at the end of it's trajectory)

    public static float canFireCannons = 2;
    public static float damageAmountRound = 5;
    public static float roundSpeed = 12.5f;
    public static float roundHeightNum = 0.5f;

    //falconet
    public static int grapeShotAmount = 4;

    public static float damageAmountRoundGrapeShot = 5;
    public static float roundSpeedGrapeShot = 7f;

    //bombard
    public static float damageAmountRoundShrapnel = 0f;

    //catapult
    public static int onagerLevel = 3;
    public static bool trebuchet = false; //shoot's a payload high in the air before it comes crashing down (it leaves an AOE on the ground)
    public static bool mangonel = true; //shoot 2 or 3 lesser payloads in quick succession

    public static float canFireCatapult = 3;
    public static float damageAmountPayload = 10;
    public static float payloadSpeed = 10f;
    public static float payloadHeightNum = 3f;

    //mangonel
    public static int mangonelAmountShot = 1;

    //trebuchet
    public static float trebuchetPayloadDeliveryDamage = 10f; //dps per sec

    // Start is called before the first frame update

    public void LoadData(GameData data)
    {
        bowLevel = data.bowLevel;
        ballista = data.ballista;
        hwacha = data.hwacha;

        culverinLevel = data.culverinLevel;
        bombard = data.bombard;
        falconet = data.falconet;

        onagerLevel = data.onagerLevel;
        trebuchet = data.trebuchet;
        mangonel = data.mangonel;
    }

    public void SaveData(ref GameData data)
    {
        data.bowLevel = bowLevel;
        data.ballista = ballista;
        data.hwacha = hwacha;

        data.culverinLevel = culverinLevel;
        data.bombard = bombard;
        data.falconet = falconet;

        data.onagerLevel = onagerLevel;
        data.trebuchet = trebuchet;
        data.mangonel = mangonel;
    }

    void Start()
    {
        bowLevel = 5;
        culverinLevel = 5;
        onagerLevel= 5;

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
                damageAmountArrows = 11.2f;
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
                damageAmountArrows = 18.7f;
                arrowSpeed = 7f;
                arrowHeightNum = 1f;

                hwachaAmountBeforeReload = 60;
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
                canFireCannons = 2.25f;
                damageAmountRound = 150f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                damageAmountRoundShrapnel = 0.075f;
            }
            if (falconet == true)
            {
                canFireCannons = 1.5f;
                damageAmountRound = 60f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                //grape shot
                grapeShotAmount = 10;

                damageAmountRoundGrapeShot = 8f;
                roundSpeedGrapeShot = 10f;
}
        }
        else if (culverinLevel == 5)
        {
            //canFireCannons = 1f;
            //damageAmountRound = 160f;

            if (bombard == true)
            {
                canFireCannons = 2.25f;
                damageAmountRound = 270f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                damageAmountRoundShrapnel = 0.1125f;
            }
            if (falconet == true)
            {
                canFireCannons = 1f;
                damageAmountRound = 80f;
                roundSpeed = 12.5f;
                roundHeightNum = 0.5f;

                //grape shot
                grapeShotAmount = 20;

                damageAmountRoundGrapeShot = 12f;
                roundSpeedGrapeShot = 10f;
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
                canFireCatapult = 3f;
                damageAmountPayload = 240f;
                payloadSpeed = 10f;
                payloadHeightNum = 6f;

                trebuchetPayloadDeliveryDamage = 60f;
            }
            if (mangonel == true)
            {
                canFireCatapult = 2f;
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
                canFireCatapult = 3f;
                damageAmountPayload = 480f;
                payloadSpeed = 10f;
                payloadHeightNum = 6f;

                trebuchetPayloadDeliveryDamage = 120f;
            }
            if (mangonel == true)
            {
                canFireCatapult = 2f;
                damageAmountPayload = 133.3f;
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
        if (bowLevel > 5)
        {
            bowLevel = 1;
            Debug.Log("Archer lvl: " + bowLevel);
        }
        if (culverinLevel > 5)
        {
            culverinLevel = 0;
            Debug.Log("Cannon lvl: " + culverinLevel);
        }
        if (onagerLevel > 5)
        {
            onagerLevel = 0;
            Debug.Log("Catapult lvl: " + onagerLevel);
        }
    }
}
