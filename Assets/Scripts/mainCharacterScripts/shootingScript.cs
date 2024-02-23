using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    public static float Rotation;

    //Archers
    private bool archers = true;
    private float timerArchers;
    private float canFireArchers = 0.5f;
    private float fireSpeedArchers = 27;
    private float arrowLifeTime = 3;
    public GameObject arrow;
    public Transform arrowSpawnPoint;

    //Cannons
    private bool cannons = true;
    private float timerCannons;
    private float canFireCannons = 2;
    private float fireSpeedCannons = 34;
    private float cannonRoundLifeTime = 2.7f;
    public GameObject cannonRound;
    public Transform cannonRoundSpawnPoint;

    //Balista
    private bool balista = true;
    private float timerBalista;
    private float canFireBalista = 3;
    private float fireSpeedBalista = 42;
    private float balistaArrowLifeTime = 2;
    public GameObject balistaArrow;
    public Transform balistaArrowSpawnPoint;

    public float angle;

    void Start()
    {
        Rotation = transform.localEulerAngles.z;
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
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void FireArchers() //Archers
    {
        if (Input.GetMouseButton(0) && timerArchers >= canFireArchers)
        {
            GameObject spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = arrowSpawnPoint.right * fireSpeedArchers;
            Destroy(spawnedBullet, arrowLifeTime);
            timerArchers = 0f;
        }
    }

    public void FireCannons() //Cannons
    {
        if (Input.GetMouseButton(0) && timerCannons >= canFireCannons)
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = cannonRoundSpawnPoint.right * fireSpeedCannons;
            Destroy(spawnedBullet, cannonRoundLifeTime);
            timerCannons = 0f;
        }
    }

    public void FireBalista() //Balista
    {
        if (Input.GetMouseButton(0) && timerBalista >= canFireBalista)
        {
            GameObject spawnedBullet = Instantiate(balistaArrow, balistaArrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = balistaArrowSpawnPoint.right * fireSpeedBalista;
            Destroy(spawnedBullet, balistaArrowLifeTime);
            timerBalista = 0f;
        }
    }
}
