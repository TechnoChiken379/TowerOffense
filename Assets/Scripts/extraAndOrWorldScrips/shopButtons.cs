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

    private string returnButtonSwitch;

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

    public void ReturnSwitch()
    {
        DisableBools();
        shopTab = true;
        if (returnButtonSwitch == "Opend Upgrades") //
        {
            SHOP.SetActive(enabled);
            UPGRADES.SetActive(!enabled); 
        }

        if (returnButtonSwitch == "Opend UP_Offensive") //
        {
            UPGRADES.SetActive(enabled);
            UP_OFFENSIVE.SetActive(!enabled);
        }

        if (returnButtonSwitch == "Opend UP_Defensive") //
        {
            UPGRADES.SetActive(enabled);
            UP_DEFENSIVE.SetActive(!enabled);
        }

        if (returnButtonSwitch == "Opend Repairs") //
        {
            SHOP.SetActive(enabled);
            REPAIRS.SetActive(!enabled);
        }

        if (returnButtonSwitch == "Opend Abilities") //
        {
            SHOP.SetActive(enabled);
            ABILITIES.SetActive(!enabled);
        }

        if (returnButtonSwitch == "Opend Ammo") //
        {
            SHOP.SetActive(enabled);
            AMMO.SetActive(!enabled);
        }
    }

    public void openShopTab() //
    {
        DisableBools();
        shopTab = true;
        if (shopTab == true)
        {
            SHOP.SetActive(enabled);
            returnButtonSwitch = "Opend Shop";
        }
    }

    public void openUpgradesTab() //
    {
        DisableBools();
        upgradesTab = true;
        if (upgradesTab == true)
        {
            SHOP.SetActive(!enabled);
            UPGRADES.SetActive(enabled);
            returnButtonSwitch = "Opend Upgrades";
        }
    }
    
    public void openUpgradesOffensiveTab() //
    {
        DisableBools();
        upgradesOffensiveTab = true;
        if (upgradesOffensiveTab == true)
        {
            UPGRADES.SetActive(!enabled);
            UP_OFFENSIVE.SetActive(enabled);
            returnButtonSwitch = "Opend UP_Offensive";
        }
    }
    
    public void openUpgradesDefensiveTab() //
    {
        DisableBools();
        upgradesDefensiveTab = true;
        if (upgradesDefensiveTab == true)
        {
            UPGRADES.SetActive(!enabled);
            UP_DEFENSIVE.SetActive(enabled);
            returnButtonSwitch = "Opend UP_Defensive";
        }
    }
    
    public void openRepairsTab() //
    {
        DisableBools();
        repairsTab = true;
        if (repairsTab == true)
        {
            SHOP.SetActive(!enabled);
            REPAIRS.SetActive(enabled);
            returnButtonSwitch = "Opend Repairs";
        }
    }
    
    public void openAbilitiesTab() //
    {
        DisableBools();
        abilitiesTab = true;
        if (abilitiesTab == true)
        {
            SHOP.SetActive(!enabled);
            ABILITIES.SetActive(enabled);
            returnButtonSwitch = "Opend Abilities";
        }
    }
    
    public void openAmmoTab() //
    {
        DisableBools();
        abilitiesTab = true;
        if (abilitiesTab == true)
        {
            SHOP.SetActive(!enabled);
            AMMO.SetActive(enabled);
            returnButtonSwitch = "Opend Ammo";
        }
    }
}
