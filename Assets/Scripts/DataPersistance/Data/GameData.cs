using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public float woodAmount;
    public float stoneAmount;
    public float steelAmount;
    public float goldAmount;

    public Vector3 playerPosition;

    //script: upgradeArmour
    public int healthLevel;
    public bool heavyTank;
    public bool lightTank;

    public int shieldLevel;
    public bool heavyShield;
    public bool lightShield;

    public int repairLevel;
    public bool heavyRepair;
    public bool lightRepair;

    //script: upgradeWeapons
    public int bowLevel;
    public bool ballista;
    public bool hwacha;

    public int culverinLevel;
    public bool bombard;
    public bool falconet;

    public int onagerLevel;
    public bool trebuchet;
    public bool mangonel;

    public GameData()
    {
        this.woodAmount = 0;
        this.stoneAmount = 0;
        this.steelAmount = 0;
        this.goldAmount = 0;

        playerPosition = new Vector3();

        healthLevel = 1;
        heavyTank = false;
        lightTank = false;

        shieldLevel = 0;
        heavyShield = false;
        lightShield = false;

        repairLevel = 0;
        heavyRepair = false;
        lightRepair = false;

        bowLevel = 1;
        ballista = false;
        hwacha = false;

        culverinLevel = 0;
        bombard = false;
        falconet = false;

        onagerLevel = 0;
        trebuchet = false;
        mangonel = false;
    }
}
