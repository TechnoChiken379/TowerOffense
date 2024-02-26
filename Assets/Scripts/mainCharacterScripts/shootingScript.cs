using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class shootingScript : MonoBehaviour
{
    public float rotationCheck;
    private float angle;

    private GameObject spawnedBullet;
    public static GameObject spawnedMousePointer;
    public GameObject mousePointer;
    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    public static float syncTimer;

    #region Weapon Vars
    //Boolean Weapons
    private bool archers = true;
    private bool cannons = true;
    private bool balista = true;

    //Can Fire Weapons
    private float canFireArchers = 0.2f;
    private float canFireCannons = 2;
    private float canFireBalista = 3;

    //Game Objects Weapons
    public GameObject arrow;
    public GameObject cannonRound;
    public GameObject balistaArrow;

    //Spawn Point Weapons
    public Transform arrowSpawnPoint;
    public Transform cannonRoundSpawnPoint;
    public Transform balistaArrowSpawnPoint;

    //Weapon Timers
    private float timerArchers;
    private float timerCannons;
    private float timerBalista;
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

        FireBalista(); //Balista script
        timerBalista += Time.deltaTime; //Timer for readyToFire
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
        if (Input.GetMouseButton(0) && timerArchers >= canFireArchers && archers == true)
        {
            spawnedBullet = arrow;
            spawnedMousePointer = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
    }

    public void FireCannons() //Cannons
    {
        if (Input.GetMouseButton(0) && timerCannons >= canFireCannons && cannons == true)
        {
            spawnedBullet = cannonRound;
            spawnedMousePointer = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
    }

    public void FireBalista() //Balista
    {
        if (Input.GetMouseButton(0) && timerBalista >= canFireBalista && balista == true)
        {
            spawnedBullet = balistaArrow;
            spawnedMousePointer = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(balistaArrow, balistaArrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerBalista = 0f;
        }
    }
}