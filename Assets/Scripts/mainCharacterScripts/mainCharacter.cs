using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class mainCharacter : MonoBehaviour
{
    //Movement vars
    public float speed;
    private float moveX;
    private float moveY;

    [SerializeField] int cameraMoveIntensityResistance; //the amount of Resistance for the intensity fo the camera move sway

    //Health, Shield vars
    //public static float maxHealth;
    public static float totalCurrentHealth;
    public Slider healthBar;

    //public static float maxShieldHealth;
    public static float totalCurrentShieldHealth;
    public Slider shieldBar;

    public float maxRepairHealth;
    public static float totalCurrentRepairHealth;
    public Slider healthRepairBar;

    private GameObject mainCamera;

    //hotkeys
    public static bool hotKey1 = true;
    public static bool hotKey2 = true;
    public static bool hotKey3 = true;
    public static bool hotKey4 = true;
    public static float hotKeyTimer = 0;

    //repair
    //public static float repairCompensation = 0.25f; //how much you can repair of every single point of damage (x100 to get procent)
    public static float totalRepairCompensation = 0f; //total HP you can repair right now
    private bool repairing = false;
    //private float repairTime = 10f;


    void Start() //Happens on start
    {
        //Movement speed
        speed = 4;

        //Starting health = Current health
        totalCurrentHealth = upgradeArmor.maxHealth;
        healthBar.maxValue = upgradeArmor.maxHealth;
        healthBar.minValue = 0;
        healthBar.value = totalCurrentHealth;

        //Starting shield health = Current shield health
        totalCurrentShieldHealth = upgradeArmor.maxShieldHealth;
        shieldBar.maxValue = upgradeArmor.maxShieldHealth;
        shieldBar.minValue = 0;
        shieldBar.value = totalCurrentShieldHealth;

        //starting repair health = current repair health
        maxRepairHealth = upgradeArmor.maxHealth;
        totalCurrentRepairHealth = maxRepairHealth;
        healthRepairBar.maxValue = maxRepairHealth;
        healthRepairBar.minValue = 0;
        healthRepairBar.value = totalCurrentRepairHealth;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() //Happens on every frame
    {
        totalCurrentRepairHealth = totalCurrentHealth + totalRepairCompensation;

        healthBar.value = totalCurrentHealth;
        healthRepairBar.value = totalCurrentRepairHealth;
        shieldBar.value = totalCurrentShieldHealth;

        hotKeyTimer += Time.deltaTime;
        HotKeyManagment();

        Repairing();
        Movement(); //Movement script
    }

    void Movement() //Movement Script
    {
        if (!repairing)
        {
            moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.position += new Vector3(moveX, moveY, 0);
            CameraMovementOnPlayerMovement();
        }
    }

    void CameraMovementOnPlayerMovement()
    {
        Vector2 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float posX = Mathf.Lerp(mainCamera.transform.position.x, transform.position.x + (pz.x / cameraMoveIntensityResistance), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(mainCamera.transform.position.y, transform.position.y + (pz.y / cameraMoveIntensityResistance), 2f * Time.deltaTime);

        mainCamera.transform.position = new Vector3(posX, posY, mainCamera.transform.position.z);
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
        if (hotKey3 == false) { hotKey3 = true; Debug.Log(hotKey3); shootingScript.catapult = true; buttons.buttonImage3.color = buttons.colorButtonOnTrue; }
        else if (hotKey3 == true) { hotKey3 = false; Debug.Log(hotKey3); shootingScript.catapult = false; buttons.buttonImage3.color = buttons.colorButtonOnFalse; }
        hotKeyTimer = 0;
    }
    void HotKey4()
    {
        //if (hotKey4 == false) { hotKey4 = true; Debug.Log(hotKey4); shootingScript.archers = true; buttons.buttonImage4.color = buttons.colorButtonOnTrue; }
        //else if (hotKey4 == true) { hotKey4 = false; Debug.Log(hotKey4); shootingScript.archers = false; buttons.buttonImage4.color = buttons.colorButtonOnFalse; }
        //hotKeyTimer = 0;
    }

    //public static void TakenDamageCalculation(float damageTaken)
    //{
    //    if (mainCharacter.totalCurrentShieldHealth >= (damageTaken / 2))
    //    {
    //        mainCharacter.totalCurrentShieldHealth -= (damageTaken / 2);
    //        mainCharacter.totalCurrentHealth -= (damageTaken / 2);
    //    }
    //    else if (mainCharacter.totalCurrentShieldHealth > 0 && !(mainCharacter.totalCurrentShieldHealth >= (damageTaken / 2)))
    //    {
    //        damageTaken -= mainCharacter.totalCurrentShieldHealth;
    //        mainCharacter.totalCurrentShieldHealth = 0;
    //        mainCharacter.totalCurrentHealth -= damageTaken;
    //    } else if (mainCharacter.totalCurrentShieldHealth == 0f)
    //    {
    //        mainCharacter.totalCurrentHealth -= damageTaken;
    //    }
    //}

    public void Repairing()
    {
        if (Input.GetKey(KeyCode.F) && totalRepairCompensation > 0f 
            && resources.wood > 0f
            && resources.stone > 0f
            && resources.steel > 0f)
        {
            repairing = true;

            resources.wood -= upgradeArmor.resourceUsage;
            resources.stone -= upgradeArmor.resourceUsage;
            resources.steel -= upgradeArmor.resourceUsage;

            totalCurrentHealth = Mathf.MoveTowards(totalCurrentHealth, totalCurrentHealth + totalRepairCompensation, upgradeArmor.repairTime * Time.deltaTime);
            totalRepairCompensation = Mathf.MoveTowards(totalRepairCompensation, 0f, upgradeArmor.repairTime * Time.deltaTime);
        } else { repairing = false; }
        Debug.Log(totalRepairCompensation);
    }

    public static void TakenDamageCalculation(float damageTaken)
    {
        if (mainCharacter.totalCurrentShieldHealth >= (damageTaken / 2))
        {
            mainCharacter.totalCurrentShieldHealth -= (damageTaken / 2);
            mainCharacter.totalCurrentHealth -= (damageTaken / 4);
        }
        else if (mainCharacter.totalCurrentShieldHealth > 0 && !(mainCharacter.totalCurrentShieldHealth >= (damageTaken / 2)))
        {
            damageTaken -= mainCharacter.totalCurrentShieldHealth;
            mainCharacter.totalCurrentShieldHealth = 0;
            mainCharacter.totalCurrentHealth -= (damageTaken / 2);
        }
        else if (mainCharacter.totalCurrentShieldHealth == 0f)
        {
            mainCharacter.totalCurrentHealth -= damageTaken;
        }
    }

    public static void DetermineTotalRepairValue(float damageTaken)
    {
        if (mainCharacter.totalCurrentShieldHealth >= (damageTaken / 2))
        {
            totalRepairCompensation += (upgradeArmor.repairCompensation * damageTaken) / 4;
        }
        else if (mainCharacter.totalCurrentShieldHealth > 0 && !(mainCharacter.totalCurrentShieldHealth >= (damageTaken / 2)))
        {
            totalRepairCompensation += (upgradeArmor.repairCompensation * damageTaken) / 4;
        }
        else if (mainCharacter.totalCurrentShieldHealth == 0f)
        {
            totalRepairCompensation += upgradeArmor.repairCompensation * damageTaken;
        }
    }
}