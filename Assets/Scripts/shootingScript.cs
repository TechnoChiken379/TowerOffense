using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    public static float Rotation;

    //Archers
    private bool archers = true;
    private float timerArchers;
    private float canFireArchers = 0;
    private float fireSpeedArchers = 30;
    private float arrowLifeTime = 2;
    public GameObject arrow;
    public Transform arrowSpawnPoint;

    //Cannons
    private bool cannons = false;
    private float timerCannons;
    private float canFireCannons;
    private float fireSpeedCannons;
    private float cannonRoundLifeTime;
    public GameObject cannonRound;
    public Transform cannonRoundSpawnPoint;

    //Balista
    private bool balista = false;
    private float timerBalista;
    private float canFireBalista;
    private float fireSpeedBalista;
    private float balistaArrowLifeTime;
    public GameObject balistaArrow;
    public Transform balistaArrowSpawnPoint;

    void Start()
    {
        Debug.Log("update");
    }

    void Update()
    {
        Debug.Log("update");
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
        Rotation = transform.localEulerAngles.z;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void FireArchers() //Archers
    {
        Debug.Log("can shoot");
        if (Input.GetMouseButton(0) && timerArchers >= canFireArchers)
        {
            Debug.Log("Shooting");
            GameObject spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = arrowSpawnPoint.right * fireSpeedArchers;
            Destroy(spawnedBullet, arrowLifeTime);
            timerArchers = 0f;
        }
    }

    public void FireCannons() //Cannons
    {
        if (Input.GetMouseButton(0) && timerCannons >= canFireCannons)
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = cannonRoundSpawnPoint.right * fireSpeedCannons;
            Destroy(spawnedBullet, cannonRoundLifeTime);
            timerCannons = 0f;
        }
    }

    public void FireBalista() //Balista
    {
        if (Input.GetMouseButton(0) && timerBalista >= canFireBalista)
        {
            GameObject spawnedBullet = Instantiate(balistaArrow, balistaArrowSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = balistaArrowSpawnPoint.right * fireSpeedBalista;
            Destroy(spawnedBullet, balistaArrowLifeTime);
            timerBalista = 0f;
        }
    }
}
