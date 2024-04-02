using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityScript : MonoBehaviour
{
    //idea's
    //arty strike (probably arrow's that rain down on enemies)
    //supply drop (probably for health and shield)
    //overdrive (faster movement and attack speed and slow time down time a bit)

    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    private float abilityTimer;
    private float abilityCoolDown = 10f;

    //artillery strike
    public static int artilleryStrikeAmount = 10;
    private int artilleryStrikeArrowAmountFired = 25;

    public GameObject ArtilleryArrow;
    float spawnDistance = 20f;

    private bool FiredArtillery = false;
    private float shootArtillery = 0.01f;
    private float artilleryTime;
    private int artilleryAmountShot;

    public static float damageAmountArrows = 100;
    public static float arrowSpeed = 20f;
    public static float arrowHeightNum = 7.5f;

    Vector2 playerPosition;
    Vector2 spawn;
    Vector2 spawnPosition;

    //supply drop
    public static int supplyDropAmount = 0;


    //overdrive
    public static int OverdriveAmount = 0;


    void Start()
    {
        abilityTimer = abilityCoolDown;
    }

    void Update()
    {
        abilityTimer += Time.deltaTime;
        Abilities();

        #region Artillery
        if (FiredArtillery)
        {
            ShootArtillery();
        }
        #endregion
    }

    public void Abilities()
    {
        if (Input.GetKeyDown(KeyCode.Space) && artilleryStrikeAmount > 0 && abilityTimer >= abilityCoolDown) ArtilleryStrike(); abilityTimer = 0f;
        if (Input.GetKeyDown(KeyCode.Space) && supplyDropAmount > 0 && abilityTimer >= abilityCoolDown) SupplyDrop(); abilityTimer = 0f;
        if (Input.GetKeyDown(KeyCode.Space) && OverdriveAmount > 0 && abilityTimer >= abilityCoolDown) Overdrive(); abilityTimer = 0f;
    }

    #region ability method's
    public void ArtilleryStrike()
    {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        playerPosition = new Vector2(transform.position.x, transform.position.y);

        spawn = (playerPosition - worldMousePosition).normalized;
        spawnPosition = playerPosition - spawn * -spawnDistance;

        artilleryStrikeAmount--;

        //
        artilleryTime = shootArtillery;
        artilleryAmountShot = 0;
        FiredArtillery = true;
    }
    public void ShootArtillery()
    {
        artilleryTime += Time.deltaTime;

        if (artilleryTime >= shootArtillery)
        {
            GameObject spawnedBullet = Instantiate(ArtilleryArrow, spawnPosition, Quaternion.Euler(0, 0, 0));

            artilleryAmountShot++;
            artilleryTime = 0f;
        }

        if (artilleryAmountShot >= artilleryStrikeArrowAmountFired)
        {
            FiredArtillery = false;
        }
    }

    public void SupplyDrop()
    {

    }
    public void Overdrive()
    {

    }
    #endregion
}
