using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    //Health upgrades
    private bool healthUpgrade1 = false;
    private bool healthUpgrade2 = false;
    private bool healthUpgrade3 = false;
    private bool healthUpgrade4 = false;
    private bool healthUpgrade5 = false;

    //Shield upgrades
    private bool shieldUpgrade1 = false;
    private bool shieldUpgrade2 = false;
    private bool shieldUpgrade3 = false;

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
        UpgradesManager(); //Upgrades script
        
    }

    void UpgradesManager()
    {
        if (healthUpgrade1 == true) maxHealth = 120;
        if (healthUpgrade2 == true && healthUpgrade1 == true) maxHealth = 140;
        if (healthUpgrade3 == true && healthUpgrade2 == true) maxHealth = 170;
        if (healthUpgrade4 == true && healthUpgrade3 == true) maxHealth = 210;
        if (healthUpgrade5 == true && healthUpgrade4 == true) maxHealth = 250;

        if (shieldUpgrade1 == true) maxShieldHealth = 20;
        if (shieldUpgrade2 == true && shieldUpgrade1 == true) maxShieldHealth = 50;
        if (shieldUpgrade3 == true && shieldUpgrade2 == true) maxShieldHealth = 100;
    }

    void Movement() //Movement Script
    {
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0);
    }

    void HotKeyManagment()
    {
        if (Input.GetKey(KeyCode.Alpha1) && hotKeyTimer > 0.7f) HotKey1();
        if (Input.GetKey(KeyCode.Alpha2) && hotKeyTimer > 0.7f) HotKey2();
        if (Input.GetKey(KeyCode.Alpha3) && hotKeyTimer > 0.7f) HotKey3();
        if (Input.GetKey(KeyCode.Alpha4) && hotKeyTimer > 0.7f) HotKey4();
    }

    void HotKey1()
    {
        if (hotKey1 == false) { hotKey1 = true; Debug.Log(hotKey1); shootingScript.archers = true; }
        else if (hotKey1 == true) { hotKey1 = false; Debug.Log(hotKey1); shootingScript.archers = false; }
        hotKeyTimer = 0;
    }
    void HotKey2()
    {
        if (hotKey2 == false) { hotKey2 = true; Debug.Log(hotKey2); shootingScript.cannons = true; }
        else if (hotKey2 == true) { hotKey2 = false; Debug.Log(hotKey2); shootingScript.cannons = false; }
        hotKeyTimer = 0;
    }
    void HotKey3()
    {
        if (hotKey3 == false) { hotKey3 = true; Debug.Log(hotKey3); shootingScript.balista = true; }
        else if (hotKey3 == true) { hotKey3 = false; Debug.Log(hotKey3); shootingScript.balista = false; }
        hotKeyTimer = 0;
    }
    void HotKey4()
    {
        //if (hotKey4 == false) { hotKey4 = true; Debug.Log(hotKey4); shootingScript.archers = true; }
        //else if (hotKey4 == true) { hotKey4 = false; Debug.Log(hotKey4); shootingScript.archers = false; }
        //hotKeyTimer = 0;
    }
}