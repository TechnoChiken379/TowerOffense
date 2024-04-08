using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRightAbility : MonoBehaviour
{
    public GameObject Artillery; 
    public GameObject SupplyDrop; 

    void Start()
    {
        
    }

    void Update()
    {
        if (abilityScript.artilleryStrikeAmount > 0)
        {
            Artillery.SetActive(true);
            SupplyDrop.SetActive(false);
        } 
        else if (abilityScript.supplyDropAmount > 0)
        {
            Artillery.SetActive(false);
            SupplyDrop.SetActive(true);
        }
        else
        {
            Artillery.SetActive(false);
            SupplyDrop.SetActive(false);
        }
    }
}
