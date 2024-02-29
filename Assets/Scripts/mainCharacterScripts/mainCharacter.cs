using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainCharacter : MonoBehaviour
{
    //Movement vars
    public float speed;
    private float moveX;
    private float moveY;

    //Health, Shield vars
    public float maxHealth;
    private float totalCurrentHealth;
    public Slider healthBar;

    public float maxShieldHealth;
    private float totalCurrentShieldHealth;
    public Slider shieldBar;

    public static bool hotKey1 = true;
    public static bool hotKey2 = true;
    public static bool hotKey3 = true;
    public static bool hotKey4 = true;
    public static float hotKeyTimer = 0;

    void Start() //Happens on start
    {
        //Movement speed
        speed = 4;

        //Starting health = Current health
        maxHealth = 100;
        totalCurrentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0;
        healthBar.value = totalCurrentHealth;

        //Starting shield health = Current shield health
        maxShieldHealth = 0;
        totalCurrentShieldHealth = maxShieldHealth;
        shieldBar.maxValue = maxShieldHealth;
        shieldBar.minValue = 0;
        shieldBar.value = totalCurrentShieldHealth;
    }

    void Update() //Happens on every frame
    {
        hotKeyTimer += Time.deltaTime;
        HotKeyManagment();

        Movement(); //Movement script
    }

    void Movement() //Movement Script
    {
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0);
    }

    void HotKeyManagment()
    {
        if (Input.GetKey(KeyCode.Alpha1) && hotKeyTimer > 0.3f) HotKey1();
        if (Input.GetKey(KeyCode.Alpha2) && hotKeyTimer > 0.3f) HotKey2();
        if (Input.GetKey(KeyCode.Alpha3) && hotKeyTimer > 0.3f) HotKey3();
        if (Input.GetKey(KeyCode.Alpha4) && hotKeyTimer > 0.3f) HotKey4();
    }

    void HotKey1()
    {
        if (hotKey1 == false) { hotKey1 = true; Debug.Log(hotKey1); shootingScript.archers = true; buttons.buttonImage1.color = buttons.colorButtonOnTrue; }
        else if (hotKey1 == true) { hotKey1 = false; Debug.Log(hotKey1); shootingScript.archers = false; buttons.buttonImage1.color = buttons.colorButtonOnFalse; }
        hotKeyTimer = 0;
    }
    void HotKey2()
    {
        if (hotKey2 == false) { hotKey2 = true; Debug.Log(hotKey2); shootingScript.cannons = true; buttons.buttonImage2.color = buttons.colorButtonOnTrue; }
        else if (hotKey2 == true) { hotKey2 = false; Debug.Log(hotKey2); shootingScript.cannons = false; buttons.buttonImage2.color = buttons.colorButtonOnFalse; }
        hotKeyTimer = 0;
    }
    void HotKey3()
    {
        if (hotKey3 == false) { hotKey3 = true; Debug.Log(hotKey3); shootingScript.balista = true; buttons.buttonImage3.color = buttons.colorButtonOnTrue; }
        else if (hotKey3 == true) { hotKey3 = false; Debug.Log(hotKey3); shootingScript.balista = false; buttons.buttonImage3.color = buttons.colorButtonOnFalse; }
        hotKeyTimer = 0;
    }
    void HotKey4()
    {
        //if (hotKey4 == false) { hotKey4 = true; Debug.Log(hotKey4); shootingScript.archers = true; buttons.buttonImage4.color = buttons.colorButtonOnTrue; }
        //else if (hotKey4 == true) { hotKey4 = false; Debug.Log(hotKey4); shootingScript.archers = false; buttons.buttonImage4.color = buttons.colorButtonOnFalse; }
        //hotKeyTimer = 0;
    }
}