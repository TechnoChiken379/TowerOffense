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
    //archers
    public GameObject arrow;
    public GameObject ballistaArrow;
    public GameObject hwachaArrow;

    public static int hwachaAmountBeforeReload = 50;
    public static int hwachaArrowsShot = 0;
    private float timerhwacha;
    private float hwachaReloadTime = 5f;

    //cannons
    public GameObject cannonRound;
    public GameObject bombardCannonRound;
    public GameObject falconetCannonRound;

    //catapult
    public GameObject catapultPayload;
    public GameObject trebuchetCatapultPayload;
    public GameObject mangonelCatapultPayload;

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
        //bow
        if ((Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.ballista && !upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) ||
        (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.ballista && !upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) ||
        (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.ballista && !upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
        //ballista
        if ((Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && upgradeWeapons.ballista && !upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) ||
        (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && upgradeArmor.shootWhileRepairing && upgradeWeapons.ballista && !upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) ||
        (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && mainCharacter.repairing && upgradeArmor.shootWhileRepairing && upgradeWeapons.ballista && !upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(ballistaArrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
        //hwacha
        if ((Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.ballista && upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) && hwachaArrowsShot < hwachaAmountBeforeReload ||
        (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && !mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.ballista && upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) && hwachaArrowsShot < hwachaAmountBeforeReload ||
        (Input.GetMouseButton(0) && timerArchers >= upgradeWeapons.canFireArchers && archers == true && mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.ballista && upgradeWeapons.hwacha && upgradeWeapons.bowLevel > 0) && hwachaArrowsShot < hwachaAmountBeforeReload)
        {
            GameObject spawnedBullet = Instantiate(hwachaArrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));
            hwachaArrowsShot++;

            timerhwacha = 0;
            timerArchers = 0f;
        } else
        {
            timerhwacha += Time.deltaTime;
            if (timerhwacha >= hwachaReloadTime)
            {
                hwachaArrowsShot = 0;
            }
        }
    }

    public void FireCannons() //Cannons
    {
        //culverin
        if ((Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.bombard && !upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0) ||
        (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.bombard && !upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0) ||
        (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.bombard && !upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
        //bombard
        if ((Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && upgradeWeapons.bombard && !upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0) ||
        (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && upgradeArmor.shootWhileRepairing && upgradeWeapons.bombard && !upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0) ||
        (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && mainCharacter.repairing && upgradeArmor.shootWhileRepairing && upgradeWeapons.bombard && !upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
        //falconet
        if ((Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.bombard && upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0) ||
        (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && !mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.bombard && upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0) ||
        (Input.GetMouseButton(0) && timerCannons >= upgradeWeapons.canFireCannons && cannons == true && mainCharacter.repairing && upgradeArmor.shootWhileRepairing && !upgradeWeapons.bombard && upgradeWeapons.falconet && upgradeWeapons.culverinLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(cannonRound, cannonRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCannons = 0f;
        }
    }

    public void FireCatapult() //catapult
    {
        //onager
        if ((Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0) ||
        (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0) ||
        (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(catapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCatapult = 0f;
        }
        //trebuchet
        if ((Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0) ||
        (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0) ||
        (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && upgradeWeapons.trebuchet && !upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(catapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCatapult = 0f;
        }
        //mangonel
        if ((Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.trebuchet && upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0) ||
        (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.trebuchet && upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0) ||
        (Input.GetMouseButton(0) && timerCatapult >= upgradeWeapons.canFireCatapult && catapult == true && !mainCharacter.repairing && !upgradeArmor.shootWhileRepairing && !upgradeWeapons.trebuchet && upgradeWeapons.mangonel && upgradeWeapons.onagerLevel > 0))
        {
            GameObject spawnedBullet = Instantiate(catapultPayload, catapultRoundSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerCatapult = 0f;
        }
    }
}