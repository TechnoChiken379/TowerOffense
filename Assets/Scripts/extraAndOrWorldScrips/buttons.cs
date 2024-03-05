using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    public GameObject mainMenuPlay;
    public GameObject mainMenuCredits;
    public GameObject mainMenuSettings;

    public static bool repairing = false;

    private void Start()
    {
        buttonImage1 = image1;
        buttonImage2 = image2;
        buttonImage3 = image3;
        buttonImage4 = image4;

        colorButtonOnTrue.a = 0.9f;
        colorButtonOnFalse.a = 0.5f;

        mainMenuText.SetActive(true);
        mainMenuImage.SetActive(false);
        mainMenuPlay.SetActive(false);
        mainMenuCredits.SetActive(false);
        mainMenuSettings.SetActive(false);
    }

    public void HotKey1Methode()
    {
        if (mainCharacter.hotKey1 == false) { mainCharacter.hotKey1 = true; Debug.Log(mainCharacter.hotKey1); shootingScript.archers = true; buttonImage1.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey1 == true) { mainCharacter.hotKey1 = false; Debug.Log(mainCharacter.hotKey1); shootingScript.archers = false; buttonImage1.color = colorButtonOnFalse; }
        mainCharacter.hotKeyTimer = 0;
    }

    public void HotKey2Methode()
    {
        if (mainCharacter.hotKey2 == false) { mainCharacter.hotKey2 = true; Debug.Log(mainCharacter.hotKey2); shootingScript.cannons = true; buttonImage2.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey2 == true) { mainCharacter.hotKey2 = false; Debug.Log(mainCharacter.hotKey2); shootingScript.cannons = false; buttonImage2.color = colorButtonOnFalse; }
        mainCharacter.hotKeyTimer = 0;
    }

    public void HotKey3Methode()
    {
        if (mainCharacter.hotKey3 == false) { mainCharacter.hotKey3 = true; Debug.Log(mainCharacter.hotKey3); shootingScript.catapult = true; buttonImage3.color = colorButtonOnTrue; }
        else if (mainCharacter.hotKey3 == true) { mainCharacter.hotKey3 = false; Debug.Log(mainCharacter.hotKey3); shootingScript.catapult = false; buttonImage3.color = colorButtonOnFalse; }
        mainCharacter.hotKeyTimer = 0;
    }

    public void HotKey4Methode()
    {
        //if (mainCharacter.hotKey4 == false) { mainCharacter.hotKey4 = true; Debug.Log(mainCharacter.hotKey4); shootingScript.archers = true; buttonImage4.color = colorButtonOnTrue; }
        //else if (mainCharacter.hotKey4 == true) { mainCharacter.hotKey4 = false; Debug.Log(mainCharacter.hotKey4); shootingScript.archers = false; buttonImage4.color = colorButtonOnFalse; }
        //mainCharacter.hotKeyTimer = 0;
    }

    public void MainMenuStart()
    {
        mainMenuImage.SetActive(true);
        mainMenuText.SetActive(false);
    }

    public void Settings()
    {
        mainMenuImage.SetActive(false);
        mainMenuText.SetActive(false);
        mainMenuPlay.SetActive(false);
        mainMenuCredits.SetActive(false);
        mainMenuSettings.SetActive(true);
    }

    public void Play()
    {
        mainMenuImage.SetActive(false);
        mainMenuText.SetActive(false);
        mainMenuPlay.SetActive(true);
        mainMenuCredits.SetActive(false);
        mainMenuSettings.SetActive(false);
    }

    public void Credits()
    {
        mainMenuImage.SetActive(false);
        mainMenuText.SetActive(false);
        mainMenuPlay.SetActive(false);
        mainMenuCredits.SetActive(true);
        mainMenuSettings.SetActive(false);
    }

    public void GoBack()
    {
        mainMenuImage.SetActive(true);
        mainMenuText.SetActive(false);
        mainMenuPlay.SetActive(false);
        mainMenuCredits.SetActive(false);
        mainMenuSettings.SetActive(false);
    }
}
