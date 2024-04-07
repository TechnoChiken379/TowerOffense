using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShootingScript : MonoBehaviour
{
    public float rotationCheck;
    private float angle;

    private Transform player;
    public float distanceToPlayer;
    private float closeEnough = 15f; //how close does the enemy want to get

    #region Weapon Vars
    //Boolean Weapons

    //Game Objects Weapons
    //archers
    public GameObject arrow;
    public GameObject ballistaArrow;
    public GameObject hwachaArrow;

    private int hwachaArrowsShot = 0;
    private float timerhwacha;

    //cannons
    public GameObject cannonRound;
    public GameObject bombardCannonRound;
    public GameObject falconetCannonRound;

    //catapult
    public GameObject catapultPayload;
    public GameObject trebuchetCatapultPayload;
    public GameObject mangonelCatapultPayload;

    private bool FiredMangonel = false;
    private float shootMangonel = 0.05f;
    private float mangonelTime;
    private int mangonelAmountShot;

    //Spawn Point Weapons
    public Transform arrowSpawnPoint;
    public Transform cannonRoundSpawnPoint;
    public Transform catapultRoundSpawnPoint;

    //Weapon Timers
    private float timerArchers;
    private float timerCannons;
    private float timerCatapult;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        FireArchers(); //Archers script
        timerArchers += Time.deltaTime; //Timer for readyToFire

        FireCannons(); //Cannons script
        timerCannons += Time.deltaTime; //Timer for readyToFire

        FireCatapult(); //Catapult script
        timerCatapult += Time.deltaTime; //Timer for readyToFire

        #region mangonel
        if (FiredMangonel)
        {
            ShootMangonel();
        }
        #endregion 
    }

    public void FireArchers() //Archers
    {
        //bow
        if (!upgradeWeapons.ballista && !upgradeWeapons.hwacha && distanceToPlayer < closeEnough && timerArchers >= bossFunction.canAttackArrows)
        {
            GameObject spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
        //ballista
        if (!upgradeWeapons.ballista && upgradeWeapons.hwacha && distanceToPlayer < closeEnough && timerArchers >= bossFunction.canAttackArrows)
        {
            GameObject spawnedBullet = Instantiate(ballistaArrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
        //hwacha
        if (upgradeWeapons.ballista && !upgradeWeapons.hwacha && distanceToPlayer < closeEnough && timerArchers >= bossFunction.canAttackArrows && hwachaArrowsShot < bossFunction.hwachaAmountBeforeReload)
        {
            GameObject spawnedBullet = Instantiate(hwachaArrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            hwachaArrowsShot++;

            timerhwacha = 0;
            timerArchers = 0f;
        }
        else
        {
            timerhwacha += Time.deltaTime;
            if (timerhwacha >= bossFunction.hwachaReloadTime)
            {
                hwachaArrowsShot = 0;
            }
        }
    }

    public void FireCannons() //Cannons
    {
        //culverin
        if (!upgradeWeapons.bombard && !upgradeWeapons.falconet && distanceToPlayer < closeEnough && timerCannons >= bossFunction.canAttackCannonRound)
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
        //bombard
        if (!upgradeWeapons.bombard && upgradeWeapons.falconet && distanceToPlayer < closeEnough && timerCannons >= bossFunction.canAttackCannonRound)
        {
            GameObject spawnedBullet = Instantiate(bombardCannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
        //falconet
        if (upgradeWeapons.bombard && !upgradeWeapons.falconet && distanceToPlayer < closeEnough && timerCannons >= bossFunction.canAttackCannonRound)
        {
            GameObject spawnedBullet = Instantiate(falconetCannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
    }

    public void FireCatapult() //catapult
    {
        //onager
        if (!upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && distanceToPlayer < closeEnough && timerCatapult >= bossFunction.canAttackCatapultPayload)
        {
            GameObject spawnedBullet = Instantiate(catapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCatapult = 0f;
        }
        //trebuchet
        if (!upgradeWeapons.trebuchet && upgradeWeapons.mangonel && distanceToPlayer < closeEnough && timerCatapult >= bossFunction.canAttackCatapultPayload)
        {
            GameObject spawnedBullet = Instantiate(trebuchetCatapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCatapult = 0f;
        }
        //mangonel
        if (upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && distanceToPlayer < closeEnough && timerCatapult >= bossFunction.canAttackCatapultPayload)
        {
            mangonelTime = shootMangonel;
            mangonelAmountShot = 0;
            FiredMangonel = true;

            timerCatapult = 0f;
        }
    }
    #region shoot mangonel
    void ShootMangonel()
    {
        mangonelTime += Time.deltaTime;

        if (mangonelTime >= shootMangonel)
        {
            GameObject spawnedBullet = Instantiate(mangonelCatapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            mangonelAmountShot++;
            mangonelTime = 0f;
        }

        if (mangonelAmountShot >= bossFunction.mangonelAmountShot)
        {
            FiredMangonel = false;
        }
    }
    #endregion
}
