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

    private float timer;
    private bool timer1Bool;

    public static bool newGame = false;

    void Start()
    {
        buttonImage1 = image1;
        buttonImage2 = image2;
        buttonImage3 = image3;
        buttonImage4 = image4;

        colorButtonOnTrue.a = 1f;
        colorButtonOnFalse.a = 0.5f;

        mainMenuText.SetActive(true);
        mainMenuImage.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 4 && timer1Bool == true)
        {
            timer1Bool = false;
            SceneManager.LoadScene("tilemapTesting");
        }
    }

    public void HotKey1Methode()
    {
        if (mainCharacter.hotKey1 == false) { mainCharacter.hotKey1 = true; shootingScript.archers = true; buttonImage1.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey1 == true) { mainCharacter.hotKey1 = false; shootingScript.archers = false; buttonImage1.color = colorButtonOnFalse; }
    }

    public void HotKey2Methode()
    {
        if (mainCharacter.hotKey2 == false) { mainCharacter.hotKey2 = true; shootingScript.cannons = true; buttonImage2.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey2 == true) { mainCharacter.hotKey2 = false; shootingScript.cannons = false; buttonImage2.color = colorButtonOnFalse; }
    }

    public void HotKey3Methode()
    {
        if (mainCharacter.hotKey3 == false) { mainCharacter.hotKey3 = true; shootingScript.catapult = true; buttonImage3.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey3 == true) { mainCharacter.hotKey3 = false; shootingScript.catapult = false; buttonImage3.color = colorButtonOnFalse; }
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

    public void CloseShop()
    {
        SceneManager.LoadScene("tilemapTesting");
    }

    #region MainMenu

    public void DisAbleBools()
    {
        //mainMenuAnimation.SetBool("MainMenuStart", false);
        //mainMenuAnimation.SetBool("MainMenu-GoBack", false);
        //mainMenuAnimation.SetBool("Play", false);
        //mainMenuAnimation.SetBool("Play-Saves", false);
        //mainMenuAnimation.SetBool("Saves-GoBack", false);
        //mainMenuAnimation.SetBool("Settings", false);
        //mainMenuAnimation.SetBool("Settings-Audio", false);
        //mainMenuAnimation.SetBool("Audio-GoBack", false);
        //mainMenuAnimation.SetBool("Settings-KeyBinds", false);
        //mainMenuAnimation.SetBool("KeyBinds-GoBack", false);
        //mainMenuAnimation.SetBool("Credits", false);
        //mainMenuAnimation.SetBool("Credits-GoBack", false);
        //mainMenuAnimation.SetBool("NewGame", false);
        //mainMenuAnimation.SetBool("LoadGame", false);
    }

    public void MainMenuStart()
    {
        mainMenuText.SetActive(false);
        mainMenuTabList.SetActive(true);
        mainMenuAnimation.SetBool("MainMenuStart", true);
    }
    public void MainMenuGoBack()
    {
        mainMenuAnimation.SetBool("MainMenu-GoBack", true);
        mainMenuAnimation.SetBool("Play", false);
        mainMenuAnimation.SetBool("Settings", false);
        mainMenuAnimation.SetBool("Credits", false);

    }
    public void Play() 
    {
        mainMenuAnimation.SetBool("Play", true);
        mainMenuAnimation.SetBool("MainMenu-GoBack", false);
    }
    public void PlaySaves() 
    {
        mainMenuAnimation.SetBool("Play-Saves", true); 
    }
    public void SavesGoBack() 
    {
        mainMenuAnimation.SetBool("Saves-GoBack", true); 
    }
    public void Settings() 
    {
        mainMenuAnimation.SetBool("Settings", true);
        mainMenuAnimation.SetBool("MainMenu-GoBack", false);
    }
    public void SettingsAudio() 
    {
        mainMenuTabList.SetActive(false);
        mainMenuAnimation.SetBool("Settings-Audio", true);
        mainMenuAnimation.SetBool("Audio-GoBack", false);
    }
    public void AudioGoBack() 
    {
        mainMenuAnimation.SetBool("Audio-GoBack", true);
        mainMenuAnimation.SetBool("Settings-Audio", false);
    }
    public void SettingsKeyBinds() 
    {
        mainMenuAnimation.SetBool("Settings-KeyBinds", true);
        mainMenuAnimation.SetBool("KeyBinds-GoBack", false);
    }
    public void KeyBindsGoBack() 
    {
        mainMenuAnimation.SetBool("KeyBinds-GoBack", true);
        mainMenuAnimation.SetBool("Settings-KeyBinds", false);
    }
    public void Credits() 
    {
        mainMenuAnimation.SetBool("Credits", true);
        mainMenuAnimation.SetBool("MainMenu-GoBack", false);
    }
    public void LoadLastSave()
    {
        mainMenuAnimation.SetBool("LoadGame", true);
        timer1Bool = true;
        timer = 0;
    }
    public void NewGameButton()
    {
        mainMenuAnimation.SetBool("NewGame", true);
        timer1Bool = true;
        timer = 0;
        newGame = true;
    }
    #endregion
}