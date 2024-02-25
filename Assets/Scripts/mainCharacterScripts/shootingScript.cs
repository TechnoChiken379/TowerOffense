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

    private GameObject player;
    private GameObject spawnedBullet;
    private GameObject spawnedMousePointer;
    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    //Archers
    private bool archers = true;
    private float timerArchers;
    private float canFireArchers = 0.2f;
    private float fireSpeedArchers = 17;
    private float arrowLifeTime = 3;
    public GameObject arrow;
    public GameObject mousePointer;
    public Transform arrowSpawnPoint;

    //Cannons
    private bool cannons = false;
    private float timerCannons;
    private float canFireCannons = 2;
    private float fireSpeedCannons = 34;
    private float cannonRoundLifeTime = 2.7f;
    public GameObject cannonRound;
    public Transform cannonRoundSpawnPoint;

    //Balista
    private bool balista = false;
    private float timerBalista;
    private float canFireBalista = 3;
    private float fireSpeedBalista = 42;
    private float balistaArrowLifeTime = 2;
    public GameObject balistaArrow;
    public Transform balistaArrowSpawnPoint;

    void Start()
    {
        player = gameObject;
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
        var dirc = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dirc.y, dirc.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void FireArchers() //Archers
    {
        if (Input.GetMouseButton(0) && timerArchers >= canFireArchers && archers == true)
        {
            if (Input.GetMouseButton(0))
            {
                mousePosition = Input.mousePosition;
                worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                spawnedMousePointer = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            }
            spawnedBullet = arrow;
            spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));    //spawns the game object (arrow) at object.position (arrowspawnpoint.) at the angle (0, 0, angle)
            /*spawnedBullet.GetComponent<Rigidbody2D>().velocity = arrowSpawnPoint.right * fireSpeedArchers;*/  //the direction the spawned object is going times the speed that is given which = the velocity
            Destroy(spawnedBullet, arrowLifeTime);                                                          //destroys the spawned object after amount of time (arrowlifetime)
            Destroy(spawnedMousePointer, arrowLifeTime);
            timerArchers = 0f;                                                                              //resets timer
        }
    }

    public void FireCannons() //Cannons
    {
        if (Input.GetMouseButton(0) && timerCannons >= canFireCannons && cannons == true)
        {
            spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = cannonRoundSpawnPoint.right * fireSpeedCannons;
            Destroy(spawnedBullet, cannonRoundLifeTime);
            timerCannons = 0f;
        }
    }

    public void FireBalista() //Balista
    {
        if (Input.GetMouseButton(0) && timerBalista >= canFireBalista && balista == true)
        {
            spawnedBullet = Instantiate(balistaArrow, balistaArrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = balistaArrowSpawnPoint.right * fireSpeedBalista;
            Destroy(spawnedBullet, balistaArrowLifeTime);
            timerBalista = 0f;
        }
    }

    public void TurnAroundSpawnPoints()
    {
        if (90f > angle && 0f < angle)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (360f > angle && 270f < angle)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (270f > angle && 90f < angle)
        {
            transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
        }
        rotationCheck = angle;
    }
}