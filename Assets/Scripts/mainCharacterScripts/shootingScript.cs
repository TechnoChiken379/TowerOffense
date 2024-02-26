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

    public static GameObject spawnedMousePointer1;
    public static GameObject spawnedMousePointer2;
    public static GameObject spawnedMousePointer3;
    public GameObject mousePointer;
    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

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
            Destroy(spawnedMousePointer1);
            GameObject spawnedBullet = arrow;
            spawnedMousePointer1 = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
    }

    public void FireCannons() //Cannons
    {
        if (Input.GetMouseButton(0) && timerCannons >= canFireCannons && cannons == true)
        {
            Destroy(spawnedMousePointer2);
            GameObject spawnedBullet = cannonRound;
            spawnedMousePointer2 = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
    }

    public void FireBalista() //Balista
    {
        if (Input.GetMouseButton(0) && timerBalista >= canFireBalista && balista == true)
        {
            Destroy(spawnedMousePointer3);
            GameObject spawnedBullet = balistaArrow;
            spawnedMousePointer3 = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(balistaArrow, balistaArrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerBalista = 0f;
        }
    }
}