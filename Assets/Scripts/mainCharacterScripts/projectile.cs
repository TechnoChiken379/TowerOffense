using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.Unicode;

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
    

    //catapult/


    //damage
    private float damageAmount = 0f;

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
        if (Vector3.Distance(movePosition, targetSpawn.transform.position) < 0.1f) 
        { 
            if (gameObject.name == "falconetCannonRound(Clone)")
            {
                for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                {
                    GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    Destroy(spawnedBullet, 1);
                }
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
        if (gameObject.name != "hwachaArrow(Clone)")
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
        if (gameObject.name == "CatapultPayload(Clone)")
        {
            damageAmount = upgradeWeapons.damageAmountPayload;
            speed = upgradeWeapons.payloadSpeed;
            heightNum = upgradeWeapons.payloadHeightNum;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyTestScrip1>(out enemyTestScrip1 enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount);
            if (gameObject.name != "ballistaArrow(Clone)")
            {
                if (gameObject.name == "falconetCannonRound(Clone)")
                {
                    for (int i = 0; i < upgradeWeapons.grapeShotAmount; i++)
                    {
                        GameObject spawnedBullet = Instantiate(falconetCannonGrapeShot, transform.position, Quaternion.identity);
                    }
                }
                Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
    }
}