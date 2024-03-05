using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    public float rotationCheck;
    private float angle;

    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    #region Weapon Vars
    //Boolean Weapons
    public static bool archers = true;
    public static bool cannons = true;
    public static bool catapult = true;

    //Game Objects Weapons
    public GameObject arrow;
    public GameObject cannonRound;
    public GameObject catapultPayload;

    //Spawn Point Weapons
    public Transform arrowSpawnPoint;
    public Transform cannonRoundSpawnPoint;
    public Transform catapultRoundSpawnPoint;

    //Weapon Timers
    private float timerArchers;
    private float timerCannons;
    private float timerCatapult;
    #endregion

    void Start()
    {

    }

    void Update()
    {
        LookAtMe();

        FireArchers(); //Archers script
        timerArchers += Time.deltaTime; //Timer for readyToFire

        FireCannons(); //Cannons script
        timerCannons += Time.deltaTime; //Timer for readyToFire

        FireCatapult(); //Catapult script
        timerCatapult += Time.deltaTime; //Timer for readyToFire
    }

    public void LookAtMe()
    {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        angle = Mathf.Atan2(worldMousePosition.y, worldMousePosition.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void FireArchers() //Archers
    {
        if (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && upgradeWeapons.bowLevel > 0)
        {
            GameObject spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
    }

    public void FireCannons() //Cannons
    {
        if (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && upgradeWeapons.culverinLevel > 0)
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
    }

    public void FireCatapult() //Balista
    {
        if (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && upgradeWeapons.onagerLevel > 0)
        {
            GameObject spawnedBullet = Instantiate(catapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCatapult = 0f;
        }
    }
}