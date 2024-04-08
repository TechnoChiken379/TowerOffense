using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    private string fileName = "data.games_on_your_phone";

    private GameData gameData;

    private List<IDataPersistance> dataPersistancesObjects;

    private FileDataHandler dataHandler;

    public static bool saveGameBool = false;

    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more then one Data Persistance Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistancesObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    void Update()
    {
        if (saveGameBool == true)
        {
            SaveGame();
            saveGameBool = false;
            Debug.Log("SaveLock");
            if (mainCharacter.openShop == true)
            {
                SceneManager.LoadScene("ShopScene");
            }
            if (deathScreenManager.saveOnDeath == true)
            {
                SceneManager.LoadScene("DeathScreen");
                mainCharacter.totalCurrentHealth = upgradeArmor.maxHealth;
                mainCharacter.totalCurrentShieldHealth = 0;
            }
        }
        if (buttons.newGameBool == true)
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        GameData.newGame = true;
        this.gameData = new GameData();
        if (buttons.newGameBool == true)
        {
            SceneManager.LoadScene("tilemapTesting");
            buttons.newGameBool = false;
        }
        Debug.Log("New Game");
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null || buttons.newGameBool == true)
        {
            Debug.Log("No game data was found. Initializing data to default.");
            NewGame();
            buttons.newGameBool = false;
        }

        foreach (IDataPersistance dataPersistancesObj in dataPersistancesObjects)
        {
            dataPersistancesObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        Debug.Log("SAVING");
        foreach (IDataPersistance dataPersistancesObj in dataPersistancesObjects)
        {
            dataPersistancesObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistancesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistancesObjects);
    }
}
