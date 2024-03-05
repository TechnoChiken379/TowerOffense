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

    public static float maxHealth = 100f;

    //armor
    public static int shieldLevel = 0;
    public static bool shielHeavyArmor = false;
    public static bool shielLightArmor = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
