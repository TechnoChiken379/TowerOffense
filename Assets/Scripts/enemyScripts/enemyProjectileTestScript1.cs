using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectileTestScript1 : MonoBehaviour
{
    private GameObject player;
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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter");
        projectileSpawn = Instantiate(enemyWayPoint, transform.position, Quaternion.identity);
        targetSpawn = Instantiate(enemyWayPoint, player.transform.position, Quaternion.identity);

    }

    void Update()
    {
        enemyX = projectileSpawn.transform.position.x;
        targetX = targetSpawn.transform.position.x;

        dist = targetX - enemyX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(projectileSpawn.transform.position.y, targetSpawn.transform.position.y, (nextX - enemyX) / dist);
        height = heightNum * (nextX - enemyX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition; 
        if (movePosition == targetSpawn.transform.position) { Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn); }
    }
    public static Quaternion LookAtTarget(Vector2 r) { return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }


}
