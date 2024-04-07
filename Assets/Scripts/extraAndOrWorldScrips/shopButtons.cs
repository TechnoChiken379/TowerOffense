using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopButtons : MonoBehaviour
{
    private bool shopTab = true;
    private bool upgradesTab = false;
    private bool upgradesOffensiveTab = false;
    private bool upgradesDefensiveTab = false;
    private bool repairsTab = false;
    private bool abilitiesTab = false;

    public GameObject SHOP;
    public GameObject UPGRADES;
    public GameObject UP_OFFENSIVE;
    public GameObject UP_DEFENSIVE;
    public GameObject REPAIRS;
    public GameObject ABILITIES;
    public GameObject AMMO;

    private void Start()
    {
        DisableBools();
        shopTab = true;
    }

    public void CloseShop()
    {
        SceneManager.LoadScene("tilemapTesting");
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

    public void openShopTab()
    {
        DisableBools();
        shopTab = true;
        if (shopTab == true)
        {
            SHOP.SetActive(enabled);
        }
    }

    public void openUpgradesTab()
    {
        DisableBools();
        upgradesTab = true;
        if (upgradesTab == true)
        {
            SHOP.SetActive(!enabled);
            UPGRADES.SetActive(enabled);
        }
    }
    
    public void openUpgradesOffensiveTab()
    {
        DisableBools();
        upgradesOffensiveTab = true;
        if (upgradesOffensiveTab == true)
        {
            UPGRADES.SetActive(!enabled);
            UP_OFFENSIVE.SetActive(enabled);
        }
    }
    
    public void openUpgradesDefensiveTab()
    {
        DisableBools();
        upgradesDefensiveTab = true;
        if (upgradesDefensiveTab == true)
        {
            UPGRADES.SetActive(!enabled);
            UP_DEFENSIVE.SetActive(enabled);
        }
    }
    
    public void openRepairsTab()
    {
        DisableBools();
        repairsTab = true;
        if (repairsTab == true)
        {
            SHOP.SetActive(!enabled);
            REPAIRS.SetActive(enabled);
        }
    }
    
    public void openAbilitiesTab()
    {
        DisableBools();
        abilitiesTab = true;
        if (abilitiesTab == true)
        {
            SHOP.SetActive(!enabled);
            ABILITIES.SetActive(enabled);
        }
    }
    
    public void openAmmoTab()
    {
        DisableBools();
        abilitiesTab = true;
        if (abilitiesTab == true)
        {
            SHOP.SetActive(!enabled);
            AMMO.SetActive(enabled);
        }
    }
}
