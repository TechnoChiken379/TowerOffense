using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript2 : MonoBehaviour
{
    private GameObject player;
    private GameObject spawnPoint;
    [SerializeField] public GameObject target;
    public GameObject targetSpawn;

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
        spawnPoint = GameObject.FindGameObjectWithTag("spawnPoint");
        targetSpawn = Instantiate(target, player.transform.position, Quaternion.identity);
    }

    void Update()
    {
        enemyX = spawnPoint.transform.position.x;
        targetX = targetSpawn.transform.position.x;

        dist = targetX - enemyX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(spawnPoint.transform.position.y, targetSpawn.transform.position.y, (nextX - enemyX) / dist);
        height = heightNum * (nextX - enemyX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition; 
        if (movePosition == targetSpawn.transform.position) { Destroy(gameObject); Destroy(targetSpawn); }
    }
    public static Quaternion LookAtTarget(Vector2 r) { return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }


}
