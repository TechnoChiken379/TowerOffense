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

    public float speed = 7f;
    public float heightNum = 0.5f;
    public Vector3 movePosition;
    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;

    private float angle;
    private float signedAngle;

    //damage
    private float damageAmount = 0f;

    void Start()
    {
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
        targetSpawn = Instantiate(playerWayPoint, worldMousePosition, Quaternion.identity);

        calculateAngle();
        determineSpeed();
        determineDamage();
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
            speed *= 0.5f;
        } else if (angle >= 70 && angle <= 110)
        {
            speed *= 0.25f;
        }
    }

    public void determineDamage()
    {
        if (gameObject.name == "Arrow(Clone)")
        {
            Debug.Log("damage set");
            damageAmount = 5;
        }
        if (gameObject.name == "CannonRound(Clone)")
        {
            Debug.Log("damage set");

            damageAmount = 20;
        }
        if (gameObject.name == "Trabuchet(Clone)")
        {
            Debug.Log("damage set");
            damageAmount = 30;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyTestScrip1>(out enemyTestScrip1 enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount);
            Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
        }
    }
}