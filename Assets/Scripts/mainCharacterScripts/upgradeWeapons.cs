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
    public static int culverinLevel = 1;
    public static bool bombard = false;
    public static bool falconet = false;

    public static float canFireCannons = 2;
    public static float damageAmountRound = 5;

    //catapult
    public static int onagerLevel = 1;
    public static bool trebuchet = false;
    public static bool mangonel = false;

    public static float canFireCatapult = 3;
    public static float damageAmountPayload = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
