using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopButtons : MonoBehaviour
{
    private bool shopTab = true;
    private bool upgradesTab = false;
    private bool upgradesOffensiveTab = false;
    private bool upgradesDefensiveTab = false;
    private bool repairsTab = false;
    private bool abilitiesTab = false;

    private void Start()
    {
        DisableBools();
        shopTab = true;
    }

    private void DisableBools()
    {
        shopTab = false;
        upgradesTab = false;
        upgradesOffensiveTab = false;
        upgradesDefensiveTab = false;
        repairsTab = false;
        abilitiesTab = false;
    }

    private void openShopTab()
    {
        DisableBools();
        shopTab = true;
        if (shopTab == true)
        {

        }
    }
    private void openUpgradesTab()
    {
        DisableBools();
        upgradesTab = true;
        if (upgradesTab == true)
        {

        }
    }
    private void openUpgradesOffensiveTab()
    {
        DisableBools();
        upgradesOffensiveTab = true;
        if (upgradesOffensiveTab == true)
        {

        }
    }
    private void openUpgradesDefensiveTab()
    {
        DisableBools();
        upgradesDefensiveTab = true;
        if (upgradesDefensiveTab == true)
        {
            
        }
    }
    private void openRepairsTab()
    {
        DisableBools();
        repairsTab = true;
        if (repairsTab == true)
        {

        }
    }
    private void openAbilitiesTab()
    {
        DisableBools();
        abilitiesTab = true;
        if (abilitiesTab == true)
        {

        }
    }
}
