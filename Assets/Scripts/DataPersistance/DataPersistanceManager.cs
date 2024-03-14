using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;

    private List<IDataPersistance> dataPersistancesObjects;

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
        this.dataPersistancesObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No game data was found. Initializing data to default.");
            NewGame();
        }

        foreach (IDataPersistance dataPersistancesObj in dataPersistancesObjects)
        {
            dataPersistancesObj.LoadData(gameData);
        }

        Debug.Log("Loaded resources =" + gameData.woodAmount);
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistancesObj in dataPersistancesObjects)
        {
            dataPersistancesObj.SaveData(ref gameData);
        }
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
