using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class buttons : MonoBehaviour
{
    public buttons HotKey1;
    public buttons HotKey2;
    public buttons HotKey3;
    public buttons HotKey4;

    void Start()
    {
        
    }

    public void HotKey1Methode()
    {
        if (mainCharacter.hotKey1 == false) { mainCharacter.hotKey1 = true; Debug.Log(mainCharacter.hotKey1); shootingScript.archers = true; }
        else if (mainCharacter.hotKey1 == true) { mainCharacter.hotKey1 = false; Debug.Log(mainCharacter.hotKey1); shootingScript.archers = false; }
        mainCharacter.hotKeyTimer = 0;
    }
    public void HotKey2Methode()
    {
        if (mainCharacter.hotKey2 == false) { mainCharacter.hotKey2 = true; Debug.Log(mainCharacter.hotKey2); shootingScript.cannons = true; }
        else if (mainCharacter.hotKey2 == true) { mainCharacter.hotKey2 = false; Debug.Log(mainCharacter.hotKey2); shootingScript.cannons = false; }
        mainCharacter.hotKeyTimer = 0;
    }
    public void HotKey3Methode()
    {
        if (mainCharacter.hotKey3 == false) { mainCharacter.hotKey3 = true; Debug.Log(mainCharacter.hotKey3); shootingScript.balista = true; }
        else if (mainCharacter.hotKey3 == true) { mainCharacter.hotKey3 = false; Debug.Log(mainCharacter.hotKey3); shootingScript.balista = false; }
        mainCharacter.hotKeyTimer = 0;
    }
    public void HotKey4Methode()
    {
        //if (mainCharacter.hotKey4 == false) { mainCharacter.hotKey4 = true; Debug.Log(mainCharacter.hotKey4); shootingScript.archers = true; }
        //else if (mainCharacter.hotKey4 == true) { mainCharacter.hotKey4 = false; Debug.Log(mainCharacter.hotKey4); shootingScript.archers = false; }
        //mainCharacter.hotKeyTimer = 0;
    }

}
