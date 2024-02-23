using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    //Movement vars
    public float speed;
    private float moveX;
    private float moveY;

    //Health, Shield vars
    public float maxHealth;
    private float totalCurrentHealth;

    public float maxShieldHealth;
    private float totalCurrentShieldHealth;

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

        //Starting shield health = Current shield health
        maxShieldHealth = 0;
        totalCurrentShieldHealth = maxShieldHealth;
    }

    void Update()
    {

    }

    void FixedUpdate() //Happens on every frame
    {
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
}