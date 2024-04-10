using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainCharacter : MonoBehaviour, IDataPersistance
{
    //Movement vars
    public static float speed;
    private float moveX;
    private float moveY;

    [SerializeField] int cameraMoveIntensityResistance; //the amount of Resistance for the intensity fo the camera move sway

    //Health, Shield vars
    //public float maxHealth;
    public static float totalCurrentHealth = 1;
    public Slider healthBar;

   //public float maxShieldHealth;
    public static float totalCurrentShieldHealth;
    public Slider shieldBar;

    public float maxRepairHealth;
    public static float totalCurrentRepairHealth;
    public Slider healthRepairBar;

    //damage Taken var's
    public static float shieldDamageTakenVariable = 0.5f;
    public static float HealthDamageTakenShieldUp = 0.25f;
    public static float HealthDamageTakenShieldBrake = 0.5f;

    private static float randomNumber;

    private GameObject mainCamera;

    //hotkeys
    public static bool hotKey1 = true;
    public static bool hotKey2 = true;
    public static bool hotKey3 = true;
    public static bool hotKey4 = true;

    //repair
    //public static float repairCompensation = 0.25f; //how much you can repair of every single point of damage (x100 to get procent)
    public static float totalRepairCompensation = 0f; //total HP you can repair right now
    public static bool repairing = false;
    //private static float repairTime = 10f;

    public static Vector3 playerPosition;
    public GameObject shopObject;
    public Vector3 shopPosition;

    public static bool openShop = false;

    public static bool backToMainMenu = false;

    public Animator mainCharacterAnimations;
    public AnimationClip mainCharacterTest;

    void Start() //Happens on start
    {
        mainCharacterAnimations.SetInteger("AnimationIdicator", 4);

        Time.timeScale = 1;
        //Movement speed
        speed = 4;

        setValuesStart();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //if (hotKey1 == true) { buttons.buttonImage1.color = buttons.colorButtonOnTrue; } else { buttons.buttonImage1.color = buttons.colorButtonOnFalse; }
        //if (hotKey2 == true) { buttons.buttonImage2.color = buttons.colorButtonOnTrue; } else { buttons.buttonImage2.color = buttons.colorButtonOnFalse; }
        //if (hotKey3 == true) { buttons.buttonImage3.color = buttons.colorButtonOnTrue; } else { buttons.buttonImage3.color = buttons.colorButtonOnFalse; }
        //if (hotKey4 == true) { buttons.buttonImage4.color = buttons.colorButtonOnTrue; } else { buttons.buttonImage4.color = buttons.colorButtonOnFalse; }
    }

    public void LoadData(GameData data)
    {
        totalCurrentHealth = data.totalCurrentHealth;
        totalCurrentShieldHealth = data.totalCurrentShieldHealth;
        transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.totalCurrentHealth = totalCurrentHealth;
        data.totalCurrentShieldHealth = totalCurrentShieldHealth;
        data.playerPosition = findNearestShop.closestShop.transform.position;
    }

    void Update()
    {
        //playerPosition = transform.position;

        OpenShop();
        GoBackToMainMenu();
        Test(); //for testing

        setValuesUpdate();

        HotKeyManagment();

        Repairing();
        Movement(); //Movement script

        movementAnimator();
    }

    void OpenShop()
    {
        playerPosition = gameObject.transform.position;
        shopPosition = findNearestShop.closestShop.transform.position;
        if (Vector3.Distance(shopPosition, playerPosition) <= 5 && Input.GetKeyDown(KeyCode.E))
        {
            DataPersistanceManager.saveGameBool = true;
            openShop = true;
        }
    }
    void GoBackToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DataPersistanceManager.saveGameBool = true;
            backToMainMenu = true;
        }
    }
    void movementAnimator()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            mainCharacterAnimations.speed = 1;
            mainCharacterAnimations.SetInteger("AnimationIdicator", 3);
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            mainCharacterAnimations.speed = 1;
            mainCharacterAnimations.SetInteger("AnimationIdicator", 4);
        }
        else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            mainCharacterAnimations.speed = 1;
            mainCharacterAnimations.SetInteger("AnimationIdicator", 2);
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            mainCharacterAnimations.speed = 1;
            mainCharacterAnimations.SetInteger("AnimationIdicator", 1);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                mainCharacterAnimations.speed = 1;
                mainCharacterAnimations.SetInteger("AnimationIdicator", 3);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                mainCharacterAnimations.speed = 1;
                mainCharacterAnimations.SetInteger("AnimationIdicator", 4);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                mainCharacterAnimations.speed = 1;
                mainCharacterAnimations.SetInteger("AnimationIdicator", 2);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                mainCharacterAnimations.speed = 1;
                mainCharacterAnimations.SetInteger("AnimationIdicator", 1);
            }
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            mainCharacterAnimations.speed = 0;
        }
    }

    void Movement() //Movement Script
    {
        if (totalCurrentHealth > 0)
        {
            if ((!repairing && !upgradeArmor.moveWhileRepairing) ||
            (!repairing && upgradeArmor.moveWhileRepairing) ||
            (repairing && upgradeArmor.moveWhileRepairing))
            {
                moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
                moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
                transform.position += new Vector3(moveX, moveY, 0);
                CameraMovementOnPlayerMovement();
            }
        }
    }

    void CameraMovementOnPlayerMovement()
    {
        //Vector2 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float posX = Mathf.Lerp(mainCamera.transform.position.x, transform.position.x + (pz.x / cameraMoveIntensityResistance), 2f * Time.deltaTime);
        //float posY = Mathf.Lerp(mainCamera.transform.position.y, transform.position.y + (pz.y / cameraMoveIntensityResistance), 2f * Time.deltaTime);

        //mainCamera.transform.position = new Vector3(posX, posY, mainCamera.transform.position.z);
    }

    void HotKeyManagment()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) HotKey1();
        if (Input.GetKeyDown(KeyCode.Alpha2)) HotKey2();
        if (Input.GetKeyDown(KeyCode.Alpha3)) HotKey3();
        if (Input.GetKeyDown(KeyCode.Alpha4)) HotKey4();
    }

    void HotKey1()
    {
        if (hotKey1 == false) { hotKey1 = true; shootingScript.archers = true; buttons.buttonImage1.color = buttons.colorButtonOnTrue; }
        else if (hotKey1 == true) { hotKey1 = false; shootingScript.archers = false; buttons.buttonImage1.color = buttons.colorButtonOnFalse; }
    }
    void HotKey2()
    {
        if (hotKey2 == false) { hotKey2 = true; shootingScript.cannons = true; buttons.buttonImage2.color = buttons.colorButtonOnTrue; }
        else if (hotKey2 == true) { hotKey2 = false; shootingScript.cannons = false; buttons.buttonImage2.color = buttons.colorButtonOnFalse; }
    }
    void HotKey3()
    {
        if (hotKey3 == false) { hotKey3 = true; shootingScript.catapult = true; buttons.buttonImage3.color = buttons.colorButtonOnTrue; }
        else if (hotKey3 == true) { hotKey3 = false; shootingScript.catapult = false; buttons.buttonImage3.color = buttons.colorButtonOnFalse; }
    }
    void HotKey4()
    {
        //if (hotKey4 == false) { hotKey4 = true; shootingScript.archers = true; buttons.buttonImage4.color = buttons.colorButtonOnTrue; }
        //else if (hotKey4 == true) { hotKey4 = false; shootingScript.archers = false; buttons.buttonImage4.color = buttons.colorButtonOnFalse; }
        //hotKeyTimer = 0;
    }

    void setValuesStart()
    {
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
        healthRepairBar.maxValue = maxRepairHealth;
        healthRepairBar.minValue = 0;
        healthRepairBar.value = totalCurrentRepairHealth;
        totalCurrentRepairHealth = maxRepairHealth;
    }

    void setValuesUpdate()
    {
        //Updating health = Current health
        healthBar.maxValue = upgradeArmor.maxHealth;
        healthBar.minValue = 0;
        healthBar.value = totalCurrentHealth;

        //Updating shield health = Current shield health
        shieldBar.maxValue = upgradeArmor.maxShieldHealth;
        shieldBar.minValue = 0;
        shieldBar.value = totalCurrentShieldHealth;

        //Updating repair health = current repair health
        maxRepairHealth = upgradeArmor.maxHealth;
        healthRepairBar.maxValue = maxRepairHealth;
        healthRepairBar.minValue = 0;
        healthRepairBar.value = totalCurrentRepairHealth;
        totalCurrentRepairHealth = totalCurrentHealth + totalRepairCompensation;
    }

    void Test()
    {

        if ((Input.GetKeyDown(KeyCode.Alpha8)))
        {
            totalCurrentHealth = upgradeArmor.maxHealth;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha9)))
        {
            totalCurrentShieldHealth = upgradeArmor.maxShieldHealth;
        }
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
        if (Input.GetKey(KeyCode.F) 
            && totalRepairCompensation > 0f 
            && resources.woodAmount > 0f
            && resources.stoneAmount > 0f
            && resources.steelAmount > 0f
            && upgradeArmor.selfRepairLevel > 0)
        {
            repairing = true;

            resources.woodAmount -= upgradeArmor.resourceUsage * Time.deltaTime;
            resources.stoneAmount -= upgradeArmor.resourceUsage * Time.deltaTime;
            resources.steelAmount -= upgradeArmor.resourceUsage * Time.deltaTime;

            totalCurrentHealth = Mathf.MoveTowards(totalCurrentHealth, totalCurrentHealth + totalRepairCompensation, upgradeArmor.repairTime * Time.deltaTime);
            totalRepairCompensation = Mathf.MoveTowards(totalRepairCompensation, 0f, upgradeArmor.repairTime * Time.deltaTime);
        } else { repairing = false; }

        if (totalCurrentHealth + totalRepairCompensation > upgradeArmor.maxHealth && totalRepairCompensation > 0f) 
        {
            float excess = totalCurrentHealth + totalRepairCompensation - upgradeArmor.maxHealth;
            totalRepairCompensation -= excess;
        }
    }

    public static void TakenDamageCalculation(float damageTaken)
    {
        damageTaken *= upgradeArmor.deflectDamageNotTaken;

        if (upgradeArmor.ricochet)
        {
            if (damageTaken <= upgradeArmor.ricochetDamageLimit) 
            {
                randomNumber = Random.Range(1, 101);
                if (randomNumber <= upgradeArmor.ricochetchange)
                {
                    damageTaken = 0;
                }
            }
        }

        if (mainCharacter.totalCurrentShieldHealth >= (damageTaken * shieldDamageTakenVariable))
            {
                mainCharacter.totalCurrentShieldHealth -= (damageTaken * shieldDamageTakenVariable);
                mainCharacter.totalCurrentHealth -= (damageTaken * HealthDamageTakenShieldUp);
        }
        else if (mainCharacter.totalCurrentShieldHealth > 0 && !(mainCharacter.totalCurrentShieldHealth >= (damageTaken * shieldDamageTakenVariable)))
            {
                damageTaken -= mainCharacter.totalCurrentShieldHealth;
                mainCharacter.totalCurrentShieldHealth = 0;
                mainCharacter.totalCurrentHealth -= (damageTaken * HealthDamageTakenShieldBrake);
        }
        else if (mainCharacter.totalCurrentShieldHealth == 0f)
        {
                mainCharacter.totalCurrentHealth -= damageTaken;
        }
    }

    public static void DetermineTotalRepairValue(float damageTaken)
    {
        if (upgradeArmor.ricochet)
        {
            if (damageTaken <= upgradeArmor.ricochetDamageLimit)
            {
                if (randomNumber <= upgradeArmor.ricochetchange)
                {
                    damageTaken = 0;
                }
            }
        }

        if (mainCharacter.totalCurrentShieldHealth >= (damageTaken * shieldDamageTakenVariable))
        {
            totalRepairCompensation += upgradeArmor.repairCompensation * damageTaken * HealthDamageTakenShieldUp;
        }
        else if (mainCharacter.totalCurrentShieldHealth > 0 && !(mainCharacter.totalCurrentShieldHealth >= (damageTaken * shieldDamageTakenVariable)))
        {
            totalRepairCompensation += upgradeArmor.repairCompensation * damageTaken * HealthDamageTakenShieldUp;
        }
        else if (mainCharacter.totalCurrentShieldHealth == 0f)
        {
            totalRepairCompensation += upgradeArmor.repairCompensation * damageTaken;
        }
    }
}