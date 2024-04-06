using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class projectile : MonoBehaviour
{
    [SerializeField] public GameObject playerWayPoint;
    private GameObject projectileSpawn;
    private GameObject targetSpawn;

    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    private float speed = 0f;
    private float heightNum = 0f;
    public Vector3 movePosition;
    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;

    private float angle;
    private float signedAngle;

    //arrow/ random target location
    private Vector2 targetLocation;
    float randomXLocation;
    float randomYLocation;

    //cannon/
    public GameObject falconetCannonGrapeShot;

    public GameObject bombardCannonShrapnel;


    //catapult/
    public GameObject trebuchetPayload;

    //damage
    private float damageAmount = 1f;

    void Start()
    {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        calculateSpawnTarget();
        determineDamageSpeedHeight();
        calculateAngle();
        determineSpeed();
    }

    void Update()
    {
        if (angle > 82.5f && angle < 97.5f)
        {
            projectileLine();
        }
        else
        {
            projectileTrajectory();
        }
        
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        if (Vector2.Distance(movePosition, targetSpawn.transform.position) < 0.1f) 
        { 
            if (gameObject.name == "falconetCannonRound(Clone)")
            {
                for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                {
                    GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == "bombardCannonRound(Clone)")
            {
                GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
            }
            if (gameObject.name == "trebuchetPayload(Clone)")
            {
                GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
            }
            Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
        }
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }

    public void projectileLine()
    {
        Vector3 direction = (targetSpawn.transform.position - transform.position).normalized;

        movePosition = transform.position + direction * (speed * 6f) * Time.deltaTime;
    }

    public void projectileTrajectory()
    {
        playerX = projectileSpawn.transform.position.x;
        targetX = targetSpawn.transform.position.x;

        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(projectileSpawn.transform.position.y, targetSpawn.transform.position.y, (nextX - playerX) / dist);
        height = heightNum * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);
    }

    public void calculateSpawnTarget()
    {
        if (gameObject.name != "hwachaArrow(Clone)" && gameObject.name != "mangonelPayload(Clone)" && gameObject.name != "ArtilleryArrow(Clone)")
        {
            projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
            targetSpawn = Instantiate(playerWayPoint, worldMousePosition, Quaternion.identity);
        }
        if (gameObject.name == "hwachaArrow(Clone)")
        {
            randomXLocation = Random.Range(-1.0f, 1.0f);
            randomYLocation = Random.Range(-1.0f, 1.0f);

            targetLocation.x = worldMousePosition.x + randomXLocation;
            targetLocation.y = worldMousePosition.y + randomYLocation;

            projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
            targetSpawn = Instantiate(playerWayPoint, targetLocation, Quaternion.identity);
        }
        if (gameObject.name == "mangonelPayload(Clone)")
        {
            randomXLocation = Random.Range(-0.75f, 0.75f);
            randomYLocation = Random.Range(-0.75f, 0.75f);

            //randomXLocation = Random.Range(-1.0f, 1.0f);
            //randomYLocation = Random.Range(-1.0f, 1.0f);

            targetLocation.x = worldMousePosition.x + randomXLocation;
            targetLocation.y = worldMousePosition.y + randomYLocation;

            projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
            targetSpawn = Instantiate(playerWayPoint, targetLocation, Quaternion.identity);
        }
        if (gameObject.name == "ArtilleryArrow(Clone)")
        {

            randomXLocation = Random.Range(-4.0f, 4.0f);
            randomYLocation = Random.Range(-4.0f, 4.0f);

            //randomXLocation = Random.Range(-1.0f, 1.0f);
            //randomYLocation = Random.Range(-1.0f, 1.0f);

            targetLocation.x = worldMousePosition.x + randomXLocation;
            targetLocation.y = worldMousePosition.y + randomYLocation;

            projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
            targetSpawn = Instantiate(playerWayPoint, targetLocation, Quaternion.identity);
        }
    }

    public void calculateAngle()
    {
        if (projectileSpawn != null && targetSpawn != null)
        {
            Vector2 direction = targetSpawn.transform.position - projectileSpawn.transform.position;
            angle = Vector2.Angle(Vector2.right, direction);

            signedAngle = Vector2.SignedAngle(Vector2.right, direction);

            if (signedAngle < 0)
            {
                signedAngle += 360;
            }
        }
        else
        {
            Debug.LogError("Please assign both projectileSpawn and targetSpawn in the inspector.");
        }
    }

    public void determineSpeed()
    {
        if ((angle > 55 && angle < 70) || (angle > 110 && angle < 125))
        {
            speed *= 0.5f;
        } else if (angle >= 70 && angle <= 110)
        {
            speed *= 0.25f;
        }
    }

    public void determineDamageSpeedHeight()
    {
        if (gameObject.name == "Arrow(Clone)" || gameObject.name == "ballistaArrow(Clone)" || gameObject.name == "hwachaArrow(Clone)")
        {
            damageAmount = upgradeWeapons.damageAmountArrows;
            speed = upgradeWeapons.arrowSpeed;
            heightNum = upgradeWeapons.arrowHeightNum;
        }
        if (gameObject.name == "CannonRound(Clone)" || gameObject.name == "bombardCannonRound(Clone)" || gameObject.name == "falconetCannonRound(Clone)")
        {
            damageAmount = upgradeWeapons.damageAmountRound;
            speed = upgradeWeapons.roundSpeed;
            heightNum = upgradeWeapons.roundHeightNum;
        }
        if (gameObject.name == "CatapultPayload(Clone)" || gameObject.name == "trebuchetPayload(Clone)" || gameObject.name == "mangonelPayload(Clone)")
        {
            damageAmount = upgradeWeapons.damageAmountPayload;
            speed = upgradeWeapons.payloadSpeed;
            heightNum = upgradeWeapons.payloadHeightNum;
        }
        if (gameObject.name == "ArtilleryArrow(Clone)")
        {
            damageAmount = abilityScript.damageAmountArrows;
            speed = abilityScript.arrowSpeed;
            heightNum = abilityScript.arrowHeightNum;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyArcherFunction>(out enemyArcherFunction enemyComponent))
        {
            //deal damage
            enemyComponent.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        //
        if (collision.gameObject.TryGetComponent<enemyKnightFunction>(out enemyKnightFunction enemyComponent2))
        {
            //deal damage
            enemyComponent2.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        //
        if (collision.gameObject.TryGetComponent<enemyRogueFunction>(out enemyRogueFunction enemyComponent3))
        {
            //deal damage
            enemyComponent3.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        //
        if (collision.gameObject.TryGetComponent<enemyCannonFunction>(out enemyCannonFunction enemyComponent4))
        {
            //deal damage
            enemyComponent4.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        //
        if (collision.gameObject.TryGetComponent<enemyTentFunction>(out enemyTentFunction enemyComponent5))
        {
            //deal damage
            enemyComponent5.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        if (collision.gameObject.TryGetComponent<enemyCrateFunction>(out enemyCrateFunction enemyComponent6))
        {
            //deal damage
            enemyComponent6.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        if (collision.gameObject.TryGetComponent<enemyWHouseFunction>(out enemyWHouseFunction enemyComponent7))
        {
            //deal damage
            enemyComponent7.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        if (collision.gameObject.TryGetComponent<enemySHouseFunction>(out enemySHouseFunction enemyComponent8))
        {
            //deal damage
            enemyComponent8.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        if (collision.gameObject.TryGetComponent<enemyWWallFunction>(out enemyWWallFunction enemyComponent9))
        {
            //deal damage
            enemyComponent9.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        if (collision.gameObject.TryGetComponent<enemySWallFunction>(out enemySWallFunction enemyComponent10))
        {
            //deal damage
            enemyComponent10.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
        if (collision.gameObject.TryGetComponent<bossFunction>(out bossFunction enemyComponent11))
        {
            //deal damage
            enemyComponent11.DamageDealt(damageAmount);

            //destroy game object on hit
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                if (gameObject.name == "bombardCannonRound(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(bombardCannonShrapnel, transform.position, Quaternion.identity);
                }
                if (gameObject.name == "trebuchetPayload(Clone)")
                {
                    GameObject spawnedBullet = Instantiate(trebuchetPayload, transform.position, Quaternion.identity);
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
    }
}