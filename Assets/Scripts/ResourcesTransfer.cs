using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesTransfer : MonoBehaviour, IDataPersistance
{
    private float storedWood;
    public static float storedWoodSended;
    private float storedStone;
    public static float storedStoneSended;
    private float storedSteel;
    public static float storedSteelSended;
    private float storedGold;
    public static float storedGoldSended;
    private float storedHealth;
    public static float storedHealthSended;
    private float storedShield;
    public static float storedShieldSended;

    public void LoadData(GameData data)
    {
        storedWood = data.woodAmount;
        storedStone = data.stoneAmount;
        storedSteel = data.steelAmount;
        storedGold = data.goldAmount;
        mainCharacter.totalCurrentHealth = data.totalCurrentHealth;
        mainCharacter.totalCurrentShieldHealth = data.totalCurrentShieldHealth;
    }

    public void SaveData(ref GameData data)
    {
        data.woodAmount = storedWood;
        data.stoneAmount = storedStone;
        data.steelAmount = storedSteel;
        data.goldAmount = storedGold;
        data.totalCurrentHealth = mainCharacter.totalCurrentHealth;
        data.totalCurrentShieldHealth = mainCharacter.totalCurrentShieldHealth;
    }

    void Update()
    {
        resources.showedWood = (int)Mathf.Round(resources.woodAmount);
        resources.showedStone = (int)Mathf.Round(resources.stoneAmount);
        resources.showedSteel = (int)Mathf.Round(resources.steelAmount);
        resources.showedGold = (int)Mathf.Round(resources.goldAmount);

        storedWood = resources.showedWood;
        storedWoodSended = storedWood;
        storedWood = storedWoodSended;
        resources.woodAmount = storedWood;

        storedStone = resources.showedStone;
        storedStoneSended = storedStone;
        storedStone = storedStoneSended;
        resources.stoneAmount = storedStone;

        storedSteel = resources.showedSteel;
        storedSteelSended = storedSteel;
        storedSteel = storedSteelSended;
        resources.steelAmount = storedSteel;

        storedGold = resources.showedGold;
        storedGoldSended = storedGold;
        storedGold = storedGoldSended;
        resources.goldAmount = storedGold;

        storedHealth = mainCharacter.totalCurrentHealth;
        storedHealthSended = storedHealth;
        storedHealth = storedHealthSended;
        mainCharacter.totalCurrentHealth = storedHealth;

        storedShield = mainCharacter.totalCurrentShieldHealth;
        storedShieldSended = storedShield;
        storedShield = storedShieldSended;
        mainCharacter.totalCurrentShieldHealth = storedShield;
    }
}
