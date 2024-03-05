using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeArmor : MonoBehaviour
{
    //upgrade armor
    //health
    public static float maxHealth = 10f;

    //armor
    public static float maxShieldHealth = 5f;

    //self repair
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
