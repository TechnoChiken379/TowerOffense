using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionScript : MonoBehaviour
{
    private string itemDescription;
    private string itemName;
    private string itemCost;
    private Vector2 buttonPos;

    public GameObject Archers0;
    public GameObject Archers1;
    public GameObject Archers2;

    public GameObject Cannons0;
    public GameObject Cannons1;
    public GameObject Cannons2;

    public GameObject Catapult0;
    public GameObject Catapult1;
    public GameObject Catapult2;

    public GameObject Health0;
    public GameObject Health1;
    public GameObject Health2;

    public GameObject Shield0;
    public GameObject Shield1;
    public GameObject Shield2;

    public GameObject Repair0;
    public GameObject Repair1;
    public GameObject Repair2;

    public static DescriptionScript Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PathButtons();
    }

    private void Update()
    {
        
    }

    public void PathButtons()
    {
        if (upgradeWeapons.bowLevel == 3)
        {
            Archers0.SetActive(!enabled);
            Archers1.SetActive(enabled);
            Archers2.SetActive(enabled);
        }
        else
        {
            Archers0.SetActive(enabled);
            Archers1.SetActive(!enabled);
            Archers2.SetActive(!enabled);
        }

        if (upgradeWeapons.culverinLevel == 3)
        {
            Cannons0.SetActive(!enabled);
            Cannons1.SetActive(enabled);
            Cannons2.SetActive(enabled);
        }
        else
        {
            Cannons0.SetActive(enabled);
            Cannons1.SetActive(!enabled);
            Cannons2.SetActive(!enabled);
        }

        if (upgradeWeapons.onagerLevel == 3)
        {
            Catapult0.SetActive(!enabled);
            Catapult1.SetActive(enabled);
            Catapult2.SetActive(enabled);
        }
        else
        {
            Catapult0.SetActive(enabled);
            Catapult1.SetActive(!enabled);
            Catapult2.SetActive(!enabled);
        }

        if (upgradeArmor.healthLevel == 3)
        {
            Health0.SetActive(!enabled);
            Health1.SetActive(enabled);
            Health2.SetActive(enabled);
        }
        else
        {
            Health0.SetActive(enabled);
            Health1.SetActive(!enabled);
            Health2.SetActive(!enabled);
        }

        if (upgradeArmor.shieldLevel == 3)
        {
            Shield0.SetActive(!enabled);
            Shield1.SetActive(enabled);
            Shield2.SetActive(enabled);
        }
        else
        {
            Shield0.SetActive(enabled);
            Shield1.SetActive(!enabled);
            Shield2.SetActive(!enabled);
        }

        if (upgradeArmor.selfRepairLevel == 3)
        {
            Repair0.SetActive(!enabled);
            Repair1.SetActive(enabled);
            Repair2.SetActive(enabled);
        }
        else
        {
            Repair0.SetActive(enabled);
            Repair1.SetActive(!enabled);
            Repair2.SetActive(!enabled);
        }
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }

    #region Weapon Description
    public void Archers()
    {
        PathButtons();
        if (upgradeWeapons.bowLevel == 1)
        {
            itemName = "Archers Upgrade";
            itemCost = "600 wood, 200 stone, 400 steel";
            itemDescription = "Get acces to Archers LV2! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.bowLevel == 2)
        {
            itemName = "Archers Upgrade";
            itemCost = "1200 wood, 400 stone, 800 steel";
            itemDescription = "Get acces to Archers LV3! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.bowLevel == 4 && upgradeWeapons.hwacha == true)
        {
            itemName = "Hwach Upgrade";
            itemCost = "4800 wood, 1600 stone, 3200 steel";
            itemDescription = "Get acces to fast firing Hwach LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.bowLevel == 4 && upgradeWeapons.ballista == true)
        {
            itemName = "Balista Upgrade";
            itemCost = "4800 wood, 1600 stone, 3200 steel";
            itemDescription = "Get acces to strong Balista LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else
        {
            itemName = "Archers Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Archers Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }

    public void ArchersPath1()
    {
        PathButtons();
        if (upgradeWeapons.bowLevel == 3)
        {
            itemName = "Hwach Upgrade";
            itemCost = "2400 wood, 800 stone, 1600 steel";
            itemDescription = "Get acces to fast firing Hwach LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        
        else
        {
            itemName = "Hwach Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Hwach Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }

    public void ArchersPath2()
    {
        PathButtons();
        if (upgradeWeapons.bowLevel == 3)
        {
            itemName = "Balista Upgrade";
            itemCost = "2400 wood, 800 stone, 1600 steel";
            itemDescription = "Get acces to strong Balista LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }

        else
        {
            itemName = "Balista Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Balista Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }

    public void Cannons()
    {
        PathButtons();
        if (upgradeWeapons.culverinLevel == 0)
        {
            itemName = "CANNONS Upgrade";
            itemCost = "100 wood, 200 stone, 300 steel";
            itemDescription = "Get acces to cannons LV1! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.culverinLevel == 1)
        {
            itemName = "CANNONS Upgrade";
            itemCost = "200 wood, 400 stone, 600 steel";
            itemDescription = "Get acces to cannons LV2! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.culverinLevel == 2)
        {
            itemName = "CANNONS Upgrade";
            itemCost = "400 wood, 800 stone, 1200 steel";
            itemDescription = "Get acces to cannons LV3! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.culverinLevel == 3)
        {
            itemName = "CANNONS Upgrade";
            itemCost = "800 wood, 1600 stone, 2400 steel";
            itemDescription = "Get acces to cannons LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.culverinLevel == 4)
        {
            itemName = "CANNONS Upgrade";
            itemCost = "1600 wood, 3200 stone, 4800 steel";
            itemDescription = "Get acces to cannons LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else
        {
            itemName = "CANNONS Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max CANNONS Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }

    public void Catapult()
    {
        PathButtons();
        if (upgradeWeapons.onagerLevel == 0)
        {
            itemName = "Catapult Upgrade";
            itemCost = "200 wood, 300 stone, 100 steel";
            itemDescription = "Get acces to Catapult LV1! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.onagerLevel == 1)
        {
            itemName = "Catapult Upgrade";
            itemCost = "400 wood, 600 stone, 200 steel";
            itemDescription = "Get acces to Catapult LV2! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.onagerLevel == 2)
        {
            itemName = "Catapult Upgrade";
            itemCost = "800 wood, 1200 stone, 400 steel";
            itemDescription = "Get acces to Catapult LV3! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.onagerLevel == 3)
        {
            itemName = "Catapult Upgrade";
            itemCost = "1600 wood, 2400 stone, 800 steel";
            itemDescription = "Get acces to Catapult LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeWeapons.onagerLevel == 4)
        {
            itemName = "Catapult Upgrade";
            itemCost = "3200 wood, 4800 stone, 1600 steel";
            itemDescription = "Get acces to Catapult LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else
        {
            itemName = "Catapult Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Catapult Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }
    #endregion
    #region Aromr Description
    public void SelfRepair()
    {
        PathButtons();
        if (upgradeArmor.selfRepairLevel == 0)
        {
            itemName = "Self Repair Upgrade";
            itemCost = "300 wood, 200 stone, 300 steel";
            itemDescription = "Get acces to Self Repair LV1! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.selfRepairLevel == 1)
        {
            itemName = "Self Repair Upgrade";
            itemCost = "600 wood, 200 stone, 400 steel";
            itemDescription = "Get acces to Self Repair LV2! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.selfRepairLevel == 2)
        {
            itemName = "Self Repair Upgrade";
            itemCost = "1200 wood, 400 stone, 800 steel";
            itemDescription = "Get acces to Self Repair LV3! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.selfRepairLevel == 3)
        {
            itemName = "Self Repair Upgrade";
            itemCost = "2400 wood, 800 stone, 1600 steel";
            itemDescription = "Get acces to Self Repair LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.selfRepairLevel == 4)
        {
            itemName = "Self Repair Upgrade";
            itemCost = "4800 wood, 1600 stone, 3200 steel";
            itemDescription = "Get acces to Self Repair LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else
        {
            itemName = "Self Repair Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Self Repair Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }

    public void Health()
    {
        PathButtons();
        if (upgradeArmor.healthLevel == 0)
        {
            itemName = "Health Upgrade Upgrade";
            itemCost = "100 wood, 200 stone, 300 steel";
            itemDescription = "Get acces to Health Upgrade LV1! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.healthLevel == 1)
        {
            itemName = "Health Upgrade Upgrade";
            itemCost = "200 wood, 400 stone, 600 steel";
            itemDescription = "Get acces to Health Upgrade LV2! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.healthLevel == 2)
        {
            itemName = "Health Upgrade Upgrade";
            itemCost = "400 wood, 800 stone, 1200 steel";
            itemDescription = "Get acces to Health Upgrade LV3! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.healthLevel == 3)
        {
            itemName = "Health Upgrade Upgrade";
            itemCost = "800 wood, 1600 stone, 2400 steel";
            itemDescription = "Get acces to Health Upgrade LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.healthLevel == 4)
        {
            itemName = "Health Upgrade Upgrade";
            itemCost = "1600 wood, 3200 stone, 4800 steel";
            itemDescription = "Get acces to Health Upgrade LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else
        {
            itemName = "Health Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Health Upgrade " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }

    public void Shield()
    {
        PathButtons();
        if (upgradeArmor.shieldLevel == 0)
        {
            itemName = "Shield Upgrade";
            itemCost = "200 wood, 300 stone, 100 steel";
            itemDescription = "Get acces to Shield LV1! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.shieldLevel == 1)
        {
            itemName = "Shield Upgrade";
            itemCost = "400 wood, 600 stone, 200 steel";
            itemDescription = "Get acces to Shield LV2! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.shieldLevel == 2)
        {
            itemName = "Shield Upgrade";
            itemCost = "800 wood, 1200 stone, 400 steel";
            itemDescription = "Get acces to Shield LV3! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.shieldLevel == 3)
        {
            itemName = "Shield Upgrade";
            itemCost = "1600 wood, 2400 stone, 800 steel";
            itemDescription = "Get acces to Shield LV4! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else if (upgradeArmor.shieldLevel == 4)
        {
            itemName = "Shield Upgrade";
            itemCost = "3200 wood, 4800 stone, 1600 steel";
            itemDescription = "Get acces to Shield LV5! " + " Current resources: Wood = " + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
        else
        {
            itemName = "Shield Upgrade";
            itemCost = string.Empty;
            itemDescription = "Max Shield Upgrade " + " Current resources: Wood = " + resources.showedWood + ResourcesTransfer.storedWoodSended + ", Stone = " + ResourcesTransfer.storedStoneSended + ", Steel = " + ResourcesTransfer.storedSteelSended + ", Gold = " + resources.showedGold;
            DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
        }
    }
    #endregion

    public void OnCursorEnter()
    {
        DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
    }

    public void OnCursorExit()
    {
        DescriptionManager.Instance.DestroyItemInfo();
    }
}
