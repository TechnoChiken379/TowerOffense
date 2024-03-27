using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public buttons HotKey1;
    public buttons HotKey2;
    public buttons HotKey3;
    public buttons HotKey4;

    public static Image buttonImage1;
    public static Image buttonImage2;
    public static Image buttonImage3;
    public static Image buttonImage4;
    public static Color colorButtonOnTrue;
    public static Color colorButtonOnFalse;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    public GameObject mainMenuImage;
    public GameObject mainMenuText;
    public GameObject mainMenuTabList;
    public GameObject mainMenuPlay;
    public GameObject mainMenuCredits;
    public GameObject mainMenuSettings;

    public static bool repairing = false;

    public Animator mainMenuAnimation;

    public static bool newGameBool = false;
    private float timer;
    private bool loadSceneBool = false;

    void Start()
    {
        buttonImage1 = image1;
        buttonImage2 = image2;
        buttonImage3 = image3;
        buttonImage4 = image4;

        colorButtonOnTrue.a = 0.9f;
        colorButtonOnFalse.a = 0.5f;

        mainMenuText.SetActive(true);
        mainMenuImage.SetActive(true);

        loadSceneBool = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4 && loadSceneBool == true)
        {
            SceneManager.LoadScene("tilemapTesting");
            loadSceneBool = false;
        }
    }

    public void HotKey1Methode()
    {
        if (mainCharacter.hotKey1 == false) { mainCharacter.hotKey1 = true; shootingScript.archers = true; buttonImage1.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey1 == true) { mainCharacter.hotKey1 = false; shootingScript.archers = false; buttonImage1.color = colorButtonOnFalse; }
        mainCharacter.hotKeyTimer = 0;
    }

    public void HotKey2Methode()
    {
        if (mainCharacter.hotKey2 == false) { mainCharacter.hotKey2 = true; shootingScript.cannons = true; buttonImage2.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey2 == true) { mainCharacter.hotKey2 = false; shootingScript.cannons = false; buttonImage2.color = colorButtonOnFalse; }
        mainCharacter.hotKeyTimer = 0;
    }

    public void HotKey3Methode()
    {
        if (mainCharacter.hotKey3 == false) { mainCharacter.hotKey3 = true; shootingScript.catapult = true; buttonImage3.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey3 == true) { mainCharacter.hotKey3 = false; shootingScript.catapult = false; buttonImage3.color = colorButtonOnFalse; }
        mainCharacter.hotKeyTimer = 0;
    }

    public void HotKey4Methode()
    {
        //if (mainCharacter.hotKey4 == false) { mainCharacter.hotKey4 = true; shootingScript.archers = true; buttonImage4.color = colorButtonOnTrue; }
        //else if (mainCharacter.hotKey4 == true) { mainCharacter.hotKey4 = false; shootingScript.archers = false; buttonImage4.color = colorButtonOnFalse; }
        //mainCharacter.hotKeyTimer = 0;
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    #region MainMenu

    public void DisAbleBools()
    {
        mainMenuAnimation.SetBool("MainMenuStart", false);
        mainMenuAnimation.SetBool("MainMenu-GoBack", false);
        mainMenuAnimation.SetBool("Play", false);
        mainMenuAnimation.SetBool("Play-Saves", false);
        mainMenuAnimation.SetBool("Saves-GoBack", false);
        mainMenuAnimation.SetBool("Settings", false);
        mainMenuAnimation.SetBool("Settings-Audio", false);
        mainMenuAnimation.SetBool("Audio-GoBack", false);
        mainMenuAnimation.SetBool("Settings-KeyBinds", false);
        mainMenuAnimation.SetBool("KeyBinds-GoBack", false);
        mainMenuAnimation.SetBool("Credits", false);
        mainMenuAnimation.SetBool("Credits-GoBack", false);
        mainMenuAnimation.SetBool("NewGame", false);
        mainMenuAnimation.SetBool("LoadGame", false);
    }

    public void MainMenuStart()
    {
        DisAbleBools();
        mainMenuText.SetActive(false);
        mainMenuTabList.SetActive(true);
        mainMenuAnimation.SetBool("MainMenuStart", true);
    }
    public void MainMenuGoBack()
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("MainMenu-GoBack", true); 
    }
    public void Play() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Play", true);
        mainMenuAnimation.SetBool("MainMenu-GoBack", false);
    }
    public void PlaySaves() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Play-Saves", true); 
    }
    public void SavesGoBack() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Saves-GoBack", true); 
    }
    public void Settings() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Settings", true); 
    }
    public void SettingsAudio() 
    {
        DisAbleBools();
        mainMenuTabList.SetActive(false);
        mainMenuAnimation.SetBool("Settings-Audio", true); 
    }
    public void AudioGoBack() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Audio-GoBack", true); 
    }
    public void SettingsKeyBinds() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Settings-KeyBinds", true); 
    }
    public void KeyBindsGoBack() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("KeyBinds-GoBack", true); 
    }
    public void Credits() 
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("Credits", true); 
    }
    public void LoadLastSave()
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("LoadGame", true);
        timer = 0;
        loadSceneBool = true;
    }
    public void NewGameButton()
    {
        DisAbleBools();
        mainMenuAnimation.SetBool("NewGame", true);
        timer = 0;
        loadSceneBool = true;
    }
    #endregion
}