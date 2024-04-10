using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

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

    public TMP_Text itemName;
    public TMP_Text itemCost;
    public TMP_Text itemDescription;

    private string itemDescription1;
    private string itemName1;
    private string itemCost1;
    private Vector2 buttonPos;

    //public GameObject Archers0;
    //public GameObject Archers1;
    //public GameObject Archers2;

    //public GameObject Cannons0;
    //public GameObject Cannons1;
    //public GameObject Cannons2;

    //public GameObject Catapult0;
    //public GameObject Catapult1;
    //public GameObject Catapult2;

    //public GameObject Health0;
    //public GameObject Health1;
    //public GameObject Health2;

    //public GameObject Shield0;
    //public GameObject Shield1;
    //public GameObject Shield2;

    //public GameObject Repair0;
    //public GameObject Repair1;
    //public GameObject Repair2;

    private void Start()
    {
        DisableBools();
        shopTab = true;

        DataPersistanceManager.saveGameBool = true;

        //itemName1 = itemName.ToString();
        //itemCost1 = itemCost.ToString();
        //itemDescription1 = itemDescription.ToString();
    }

    public void CloseShop()
    {
        SceneManager.LoadScene("tilemapTesting");
    }

    #region ShopButtons
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
            upgradesTab = true;
            SHOP.SetActive(enabled);
            UPGRADES.SetActive(!enabled); 
        }

        if (returnButtonSwitch == "Opend UP_Offensive") //
        {
            upgradesOffensiveTab = true;
            UPGRADES.SetActive(enabled);
            UP_OFFENSIVE.SetActive(!enabled);
            returnButtonSwitch = "Opend Upgrades";
        }

        if (returnButtonSwitch == "Opend UP_Defensive") //
        {
            upgradesDefensiveTab = true;
            UPGRADES.SetActive(enabled);
            UP_DEFENSIVE.SetActive(!enabled);
            returnButtonSwitch = "Opend Upgrades";
        }

        if (returnButtonSwitch == "Opend Repairs") //
        {
            repairsTab = true;
            SHOP.SetActive(enabled);
            REPAIRS.SetActive(!enabled);
        }

        if (returnButtonSwitch == "Opend Abilities") //
        {
            abilitiesTab = true;
            SHOP.SetActive(enabled);
            ABILITIES.SetActive(!enabled);
        }

        if (returnButtonSwitch == "Opend Ammo") //
        {
            abilitiesTab = true;
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
    #endregion
    #region Buy Upgrades
    #region Archers Upgrade
    public void ArchersUpgrade()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.bowLevel == 1 && resources.woodAmount >= 600 && resources.stoneAmount >= 200 && resources.steelAmount >= 400)
        {
            resources.woodAmount -= 600;
            resources.stoneAmount -= 200;
            resources.steelAmount -= 400;
            upgradeWeapons.bowLevel = 2;
        }
        else if (upgradeWeapons.bowLevel == 2 && resources.woodAmount >= 1200 && resources.stoneAmount >= 400 && resources.steelAmount >= 800)
        {
            resources.woodAmount -= 1200;
            resources.stoneAmount -= 400;
            resources.steelAmount -= 800;
            upgradeWeapons.bowLevel = 3;
        }
        else if (upgradeWeapons.bowLevel == 4 && resources.woodAmount >= 4800 && resources.stoneAmount >= 1600 && resources.steelAmount >= 3200)
        {
            resources.woodAmount -= 4800;
            resources.stoneAmount -= 1600;
            resources.steelAmount -= 3200;
            upgradeWeapons.bowLevel = 5;
        }
        else
        {
            if (upgradeWeapons.bowLevel <= 0)
            {
                upgradeWeapons.bowLevel = 1;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Archers();
    }

    public void ArchersUpgradePath1()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.bowLevel == 3 && resources.woodAmount >= 2400 && resources.stoneAmount >= 800 && resources.steelAmount >= 1600)
        {
            resources.woodAmount -= 2400;
            resources.stoneAmount -= 800;
            resources.steelAmount -= 1600;
            upgradeWeapons.bowLevel = 4;
            upgradeWeapons.hwacha = true;
            upgradeWeapons.ballista = false;
        }
        else
        {
            if (upgradeWeapons.bowLevel <= 0)
            {
                upgradeWeapons.bowLevel = 1;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Archers();
    }

    public void ArchersUpgradePath2()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.bowLevel == 3 && resources.woodAmount >= 2400 && resources.stoneAmount >= 800 && resources.steelAmount >= 1600)
        {
            resources.woodAmount -= 2400;
            resources.stoneAmount -= 800;
            resources.steelAmount -= 1600;
            upgradeWeapons.bowLevel = 4;
            upgradeWeapons.hwacha = false;
            upgradeWeapons.ballista = true;
        }
        else
        {
            if (upgradeWeapons.bowLevel <= 0)
            {
                upgradeWeapons.bowLevel = 1;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Archers();
    }
    #endregion
    #region Cannons Upgrade
    public void CannonsUpgrade()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.culverinLevel == 0 && resources.woodAmount >= 100 && resources.stoneAmount >= 200 && resources.steelAmount >= 300)
        {
            resources.woodAmount -= 100;
            resources.stoneAmount -= 200;
            resources.steelAmount -= 300;
            upgradeWeapons.culverinLevel = 1;
        }
        else if (upgradeWeapons.culverinLevel == 1 && resources.woodAmount >= 200 && resources.stoneAmount >= 400 && resources.steelAmount >= 600)
        {
            resources.woodAmount -= 200;
            resources.stoneAmount -= 400;
            resources.steelAmount -= 600;
            upgradeWeapons.culverinLevel = 2;
        }
        else if (upgradeWeapons.culverinLevel == 2 && resources.woodAmount >= 400 && resources.stoneAmount >= 800 && resources.steelAmount >= 1200)
        {
            resources.woodAmount -= 400;
            resources.stoneAmount -= 800;
            resources.steelAmount -= 1200;
            upgradeWeapons.culverinLevel = 3;
        }
        else if (upgradeWeapons.culverinLevel == 4 && resources.woodAmount >= 1600 && resources.stoneAmount >= 3200 && resources.steelAmount >= 4800)
        {
            resources.woodAmount -= 1600;
            resources.stoneAmount -= 3200;
            resources.steelAmount -= 4800;
            upgradeWeapons.culverinLevel = 5;
        }
        else
        {
            if (upgradeWeapons.culverinLevel < 0)
            {
                upgradeWeapons.culverinLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Cannons();
    }

    public void CannonsUpgradePath1()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.culverinLevel == 3 && resources.woodAmount >= 800 && resources.stoneAmount >= 1600 && resources.steelAmount >= 2400)
        {
            resources.woodAmount -= 800;
            resources.stoneAmount -= 1600;
            resources.steelAmount -= 2400;
            upgradeWeapons.culverinLevel = 4;
            upgradeWeapons.falconet = true;
            upgradeWeapons.bombard = false;
        }
        else
        {
            if (upgradeWeapons.culverinLevel < 0)
            {
                upgradeWeapons.culverinLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Cannons();
    }

    public void CannonsUpgradePath2()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.culverinLevel == 3 && resources.woodAmount >= 800 && resources.stoneAmount >= 1600 && resources.steelAmount >= 2400)
        {
            resources.woodAmount -= 800;
            resources.stoneAmount -= 1600;
            resources.steelAmount -= 2400;
            upgradeWeapons.culverinLevel = 4;
            upgradeWeapons.falconet = false;
            upgradeWeapons.bombard = true;
        }
        else
        {
            if (upgradeWeapons.culverinLevel < 0)
            {
                upgradeWeapons.culverinLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Cannons();
    }
    #endregion
    #region Catapult Upgrade
    public void CatapultUpgrade()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.onagerLevel == 0 && resources.woodAmount >= 200 && resources.stoneAmount >= 300 && resources.steelAmount >= 100)
        {
            resources.woodAmount -= 200;
            resources.stoneAmount -= 300;
            resources.steelAmount -= 100;
            upgradeWeapons.onagerLevel = 1;
        }
        else if (upgradeWeapons.onagerLevel == 1 && resources.woodAmount >= 400 && resources.stoneAmount >= 600 && resources.steelAmount >= 200)
        {
            resources.woodAmount -= 400;
            resources.stoneAmount -= 600;
            resources.steelAmount -= 200;
            upgradeWeapons.onagerLevel = 2;
        }
        else if (upgradeWeapons.onagerLevel == 2 && resources.woodAmount >= 800 && resources.stoneAmount >= 1200 && resources.steelAmount >= 400)
        {
            resources.woodAmount -= 800;
            resources.stoneAmount -= 1200;
            resources.steelAmount -= 400;
            upgradeWeapons.onagerLevel = 3;
        }
        else if (upgradeWeapons.onagerLevel == 4 && resources.woodAmount >= 3200 && resources.stoneAmount >= 4800 && resources.steelAmount >= 1600)
        {
            resources.woodAmount -= 3200;
            resources.stoneAmount -= 4800;
            resources.steelAmount -= 1600;
            upgradeWeapons.onagerLevel = 5;
        }
        else
        {
            if (upgradeWeapons.onagerLevel < 0)
            {
                upgradeWeapons.onagerLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Catapult();
    }

    public void CatapultUpgradePath1()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.onagerLevel == 3 && resources.woodAmount >= 1600 && resources.stoneAmount >= 2400 && resources.steelAmount >= 800)
        {
            resources.woodAmount -= 1600;
            resources.stoneAmount -= 2400;
            resources.steelAmount -= 800;
            upgradeWeapons.onagerLevel = 4;
            upgradeWeapons.mangonel = false;
            upgradeWeapons.trebuchet = true;
        }
        else
        {
            if (upgradeWeapons.onagerLevel < 0)
            {
                upgradeWeapons.onagerLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Catapult();
    }

    public void CatapultUpgradePath2()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeWeapons.onagerLevel == 3 && resources.woodAmount >= 1600 && resources.stoneAmount >= 2400 && resources.steelAmount >= 800)
        {
            resources.woodAmount -= 1600;
            resources.stoneAmount -= 2400;
            resources.steelAmount -= 800;
            upgradeWeapons.onagerLevel = 4;
            upgradeWeapons.mangonel = true;
            upgradeWeapons.trebuchet = false;
        }
        else
        {
            if (upgradeWeapons.onagerLevel < 0)
            {
                upgradeWeapons.onagerLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Catapult();
    }
    #endregion
    #region Repair Upgrade
    public void SelfRepairUpgrade()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.selfRepairLevel == 0 && resources.woodAmount >= 300 && resources.stoneAmount >= 100 && resources.steelAmount >= 200)
        {
            resources.woodAmount -= 300;
            resources.stoneAmount -= 100;
            resources.steelAmount -= 200;
            upgradeArmor.selfRepairLevel = 1;
        }
        else if (upgradeArmor.selfRepairLevel == 1 && resources.woodAmount >= 600 && resources.stoneAmount >= 200 && resources.steelAmount >= 400)
        {
            resources.woodAmount -= 600;
            resources.stoneAmount -= 200;
            resources.steelAmount -= 400;
            upgradeArmor.selfRepairLevel = 2;
        }
        else if (upgradeArmor.selfRepairLevel == 2 && resources.woodAmount >= 1200 && resources.stoneAmount >= 400 && resources.steelAmount >= 800)
        {
            resources.woodAmount -= 1200;
            resources.stoneAmount -= 400;
            resources.steelAmount -= 800;
            upgradeArmor.selfRepairLevel = 3;
        }
        else if (upgradeArmor.selfRepairLevel == 4 && resources.woodAmount >= 4800 && resources.stoneAmount >= 1600 && resources.steelAmount >= 3200)
        {
            resources.woodAmount -= 4800;
            resources.stoneAmount -= 1600;
            resources.steelAmount -= 3200;
            upgradeArmor.selfRepairLevel = 5;
        }
        else
        {
            if (upgradeArmor.selfRepairLevel < 0)
            {
                upgradeArmor.selfRepairLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.SelfRepair();
    }

    public void RepairUpgradePath1()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.selfRepairLevel == 3 && resources.woodAmount >= 2400 && resources.stoneAmount >= 800 && resources.steelAmount >= 1600)
        {
            resources.woodAmount -= 2400;
            resources.stoneAmount -= 800;
            resources.steelAmount -= 1600;
            upgradeArmor.selfRepairLevel = 4;
            upgradeArmor.selfRepairLightRepair = true;
            upgradeArmor.selfRepairHeavyRepair = false;
        }
        else
        {
            if (upgradeArmor.selfRepairLevel < 0)
            {
                upgradeArmor.selfRepairLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.SelfRepair();
    }

    public void RepairUpgradePath2()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.selfRepairLevel == 3 && resources.woodAmount >= 2400 && resources.stoneAmount >= 800 && resources.steelAmount >= 1600)
        {
            resources.woodAmount -= 2400;
            resources.stoneAmount -= 800;
            resources.steelAmount -= 1600;
            upgradeArmor.selfRepairLevel = 4;
            upgradeArmor.selfRepairLightRepair = false;
            upgradeArmor.selfRepairHeavyRepair = true;
        }
        else
        {
            if (upgradeArmor.selfRepairLevel < 0)
            {
                upgradeArmor.selfRepairLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.SelfRepair();
    }
    #endregion
    #region Health Upgrade
    public void HealthUpgrade()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.healthLevel == 1 && resources.woodAmount >= 200 && resources.stoneAmount >= 400 && resources.steelAmount >= 600)
        {
            resources.woodAmount -= 200;
            resources.stoneAmount -= 400;
            resources.steelAmount -= 600;
            upgradeArmor.healthLevel = 2;
        }
        else if (upgradeArmor.healthLevel == 2 && resources.woodAmount >= 400 && resources.stoneAmount >= 800 && resources.steelAmount >= 1200)
        {
            resources.woodAmount -= 400;
            resources.stoneAmount -= 800;
            resources.steelAmount -= 1200;
            upgradeArmor.healthLevel = 3;
        }
        else if (upgradeArmor.healthLevel == 4 && resources.woodAmount >= 1600 && resources.stoneAmount >= 3200 && resources.steelAmount >= 4800)
        {
            resources.woodAmount -= 1600;
            resources.stoneAmount -= 3200;
            resources.steelAmount -= 4800;
            upgradeArmor.healthLevel = 5;
        }
        else
        {
            if (upgradeArmor.healthLevel <= 0)
            {
                upgradeArmor.healthLevel = 1;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Health();
    }

    public void HealthUpgradePath1()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.healthLevel == 3 && resources.woodAmount >= 800 && resources.stoneAmount >= 1600 && resources.steelAmount >= 2400)
        {
            resources.woodAmount -= 800;
            resources.stoneAmount -= 1600;
            resources.steelAmount -= 2400;
            upgradeArmor.healthLevel = 4;
            upgradeArmor.healthLightTank = false;
            upgradeArmor.healthHeavyTank = true;
        }
        else
        {
            if (upgradeArmor.healthLevel <= 0)
            {
                upgradeArmor.healthLevel = 1;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Health();
    }

    public void HealthUpgradePath2()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.healthLevel == 3 && resources.woodAmount >= 800 && resources.stoneAmount >= 1600 && resources.steelAmount >= 2400)
        {
            resources.woodAmount -= 800;
            resources.stoneAmount -= 1600;
            resources.steelAmount -= 2400;
            upgradeArmor.healthLevel = 4;
            upgradeArmor.healthLightTank = true;
            upgradeArmor.healthHeavyTank = false;
        }
        else
        {
            if (upgradeArmor.healthLevel <= 0)
            {
                upgradeArmor.healthLevel = 1;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Health();
    }
    #endregion
    #region Shield Upgrade
    public void ShieldUpgrade()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.shieldLevel == 0 && resources.woodAmount >= 200 && resources.stoneAmount >= 300 && resources.steelAmount >= 100)
        {
            resources.woodAmount -= 200;
            resources.stoneAmount -= 300;
            resources.steelAmount -= 100;
            upgradeArmor.shieldLevel = 1;
        }
        else if (upgradeArmor.shieldLevel == 1 && resources.woodAmount >= 400 && resources.stoneAmount >= 600 && resources.steelAmount >= 200)
        {
            resources.woodAmount -= 400;
            resources.stoneAmount -= 600;
            resources.steelAmount -= 200;
            upgradeArmor.shieldLevel = 2;
        }
        else if (upgradeArmor.shieldLevel == 2 && resources.woodAmount >= 800 && resources.stoneAmount >= 1200 && resources.steelAmount >= 400)
        {
            resources.woodAmount -= 800;
            resources.stoneAmount -= 1200;
            resources.steelAmount -= 400;
            upgradeArmor.shieldLevel = 3;
        }
        else if (upgradeArmor.shieldLevel == 4 && resources.woodAmount >= 3200 && resources.stoneAmount >= 4800 && resources.steelAmount >= 1600)
        {
            resources.woodAmount -= 3200;
            resources.stoneAmount -= 4800;
            resources.steelAmount -= 1600;
            upgradeArmor.shieldLevel = 5;
        }
        else
        {
            if (upgradeArmor.shieldLevel < 0)
            {
                upgradeArmor.shieldLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Shield();
    }

    public void ShieldUpgradePath1()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.shieldLevel == 3 && resources.woodAmount >= 1600 && resources.stoneAmount >= 2400 && resources.steelAmount >= 800)
        {
            resources.woodAmount -= 1600;
            resources.stoneAmount -= 2400;
            resources.steelAmount -= 800;
            upgradeArmor.shieldLevel = 4;
            upgradeArmor.shieldLightArmor = false;
            upgradeArmor.shieldHeavyArmor = true;
        }
        else
        {
            if (upgradeArmor.shieldLevel < 0)
            {
                upgradeArmor.shieldLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Shield();
    }

    public void ShieldUpgradePath2()
    {
        DescriptionManager.Instance.DestroyItemInfo();
        if (upgradeArmor.shieldLevel == 3 && resources.woodAmount >= 1600 && resources.stoneAmount >= 2400 && resources.steelAmount >= 800)
        {
            resources.woodAmount -= 1600;
            resources.stoneAmount -= 2400;
            resources.steelAmount -= 800;
            upgradeArmor.shieldLevel = 4;
            upgradeArmor.shieldLightArmor = true;
            upgradeArmor.shieldHeavyArmor = false;
        }
        else
        {
            if (upgradeArmor.shieldLevel < 0)
            {
                upgradeArmor.shieldLevel = 0;
            }
        }
        DataPersistanceManager.saveGameBool = true;
        DescriptionScript.Instance.Shield();
    }
    #endregion
    #endregion
    #region Item Descriptions
    public virtual string GetItemDescription()
    {
        return itemDescription1;
    }

    public void OnCursorEnter()
    {
        DescriptionManager.Instance.DisplayItemInfo(itemName1, itemCost1, itemDescription1, buttonPos);
    }

    public void OnCursorExit()
    {
        DescriptionManager.Instance.DestroyItemInfo();
    }
    #endregion
    #region Repair
    public void HealthRepair()
    {
        mainCharacter.Instance.Repairing();
    }
    #endregion
}
