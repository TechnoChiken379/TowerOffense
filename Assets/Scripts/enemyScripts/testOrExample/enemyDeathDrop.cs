using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyDeathDrop : MonoBehaviour
{
    //private GameObject player;
    [SerializeField] public GameObject enemyWayPoint;
    private GameObject projectileSpawn;
    private GameObject targetSpawn;

    private float speed = 3f;
    private float heightNum = 0.5f;
    public Vector3 movePosition;

    private float enemyX;
    private float targetX;

    private float nextX;
    private float dist;

    private float baseY;
    private float height;

    private float angle;
    private float signedAngle;

    //random target location
    private Vector2 targetLocation;

    float randomXLocation;
    float randomYLocation;

    //scripts
    private enemyArcherFunction enemyArcherScriptReference;
    private enemyRogueFunction enemyRogueScriptReference;
    private enemyKnightFunction enemyKnightScriptReference;
    private enemyCannonFunction enemyCannonScriptReference;

    //building
    private enemyTentFunction enemyTentScriptReference;
    private enemyCrateFunction enemyCrateScriptReference;
    private enemyWHouseFunction enemyWHouseScriptReference;
    private enemySHouseFunction enemySHouseScriptReference;

    private enemyWWallFunction enemyWWallScriptReference;
    private enemySWallFunction enemySWallScriptReference;

    //boss
    private bossFunction bossFuntionScriptReference;

    //dropped
    private float DroppedGold = 0;
    private float DroppedWood = 0;
    private float DroppedStone = 0;
    private float DroppedSteel = 0;

    //auto pick up
    private float time;
    private float timeAlive = 3f;

    private void Start()
    {
        determineTargetLocation();
        projectileSpawn = Instantiate(enemyWayPoint, transform.position, Quaternion.identity);
        targetSpawn = Instantiate(enemyWayPoint, targetLocation, Quaternion.identity);

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
        if (projectileSpawn != null && targetSpawn != null && Vector3.Distance(movePosition, targetSpawn.transform.position) < 0.1f) { Destroy(targetSpawn); Destroy(projectileSpawn); }
        AutoPickUp();
    }
    public static Quaternion LookAtTarget(Vector2 r) { return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }

    public void projectileLine()
    {
        if (projectileSpawn != null && targetSpawn != null)
        {
            Vector3 direction = (targetSpawn.transform.position - transform.position).normalized;

            movePosition = transform.position + direction * (speed * 3f) * Time.deltaTime;
        }
    }

    public void projectileTrajectory()
    {
        if (projectileSpawn != null && targetSpawn != null)
        {
            enemyX = projectileSpawn.transform.position.x;
            targetX = targetSpawn.transform.position.x;

            dist = targetX - enemyX;
            nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
            baseY = Mathf.Lerp(projectileSpawn.transform.position.y, targetSpawn.transform.position.y, (nextX - enemyX) / dist);
            height = heightNum * (nextX - enemyX) * (nextX - targetX) / (-0.25f * dist * dist);

            movePosition = new Vector3(nextX, baseY + height, transform.position.z);
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
        if (angle > 55 && angle < 70 || angle > 110 && angle < 125)
        {
            speed *= 0.65f;
        }
        else if (angle >= 70 && angle <= 110)
        {
            speed *= 0.4f;
        }
    }

    public void determineTargetLocation()
    {
        randomXLocation = Random.Range(-1.0f, 1.0f);
        randomYLocation = Random.Range(-1.0f, 1.0f);

        targetLocation.x = transform.position.x + randomXLocation;
        targetLocation.y = transform.position.y + randomYLocation;
    }

    #region script reference
    public void SetEnemyScriptReference(enemyArcherFunction enemyScript)
    {
        enemyArcherScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyRogueFunction enemyScript)
    {
        enemyRogueScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyKnightFunction enemyScript)
    {
        enemyKnightScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyCannonFunction enemyScript)
    {
        enemyCannonScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyTentFunction enemyScript)
    {
        enemyTentScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyCrateFunction enemyScript)
    {
        enemyCrateScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyWHouseFunction enemyScript)
    {
        enemyWHouseScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemySHouseFunction enemyScript)
    {
        enemySHouseScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemyWWallFunction enemyScript)
    {
        enemyWWallScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(enemySWallFunction enemyScript)
    {
        enemySWallScriptReference = enemyScript;
    }
    public void SetEnemyScriptReference(bossFunction enemyScript)
    {
        bossFuntionScriptReference = enemyScript;
    }
    #endregion

    #region determine amount dropped
    public void DetermineAmountGold(float amount)
    {
        DroppedGold = amount;
        DroppedWood = 0;
        DroppedStone = 0;
        DroppedSteel = 0;
    }

    public void DetermineAmountWood(float amount)
    {
        DroppedGold = 0;
        DroppedWood = amount;
        DroppedStone = 0;
        DroppedSteel = 0;
    }

    public void DetermineAmountStone(float amount)
    {
        DroppedGold = 0;
        DroppedWood = 0;
        DroppedStone = amount;
        DroppedSteel = 0;
    }

    public void DetermineAmountSteel(float amount)
    {
        DroppedGold = 0;
        DroppedWood = 0;
        DroppedStone = 0;
        DroppedSteel = amount;
    }
    #endregion

    void AutoPickUp()
    {
        time += Time.deltaTime;
        if (time >= timeAlive)
        {
            resources.woodAmount += DroppedWood;
            resources.stoneAmount += DroppedStone;
            resources.steelAmount += DroppedSteel;
            resources.goldAmount += DroppedGold;

            Destroy(gameObject);
            if (projectileSpawn != null && targetSpawn != null)
            {
                Destroy(targetSpawn); Destroy(projectileSpawn);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            resources.woodAmount += DroppedWood;
            resources.stoneAmount += DroppedStone;
            resources.steelAmount += DroppedSteel;
            resources.goldAmount += DroppedGold;

            Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
        }
    }
}
