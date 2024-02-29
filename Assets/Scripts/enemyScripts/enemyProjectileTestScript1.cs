using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyProjectileTestScript1 : MonoBehaviour
{
    private GameObject player;
    [SerializeField] public GameObject enemyWayPoint;
    private GameObject projectileSpawn;
    private GameObject targetSpawn;

    private float speed = 5f;
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

    public static float enemyArrowDamageAmount = 5;

    private void Start()
    { 
        player = GameObject.FindGameObjectWithTag("mainCharacter");
        projectileSpawn = Instantiate(enemyWayPoint, transform.position, Quaternion.identity);
        targetSpawn = Instantiate(enemyWayPoint, player.transform.position, Quaternion.identity);

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
        if (Vector3.Distance(movePosition, targetSpawn.transform.position) < 0.1f) { Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn); }
    }
    public static Quaternion LookAtTarget(Vector2 r) { return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }

    public void projectileLine()
    {
        Vector3 direction = (targetSpawn.transform.position - transform.position).normalized;

        movePosition = transform.position + direction * (speed * 3f) * Time.deltaTime;
    }

    public void projectileTrajectory()
    {
        enemyX = projectileSpawn.transform.position.x;
        targetX = targetSpawn.transform.position.x;

        dist = targetX - enemyX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(projectileSpawn.transform.position.y, targetSpawn.transform.position.y, (nextX - enemyX) / dist);
        height = heightNum * (nextX - enemyX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            //mainCharacter.totalCurrentHealth -= enemyArrowDamageAmount;
            mainCharacter.TakenDamageCalculation(enemyArrowDamageAmount);
            Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
        }
    }
}
