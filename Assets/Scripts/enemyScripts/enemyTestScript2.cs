using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTestScript2 : MonoBehaviour
{
    public GameObject player;
    public static float speed = 10f;
    public static float heightNum = 0.5f;
    public Vector3 movePosition;
    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter");
    }

    void Update()
    {
        playerX = player.transform.position.x;
        targetX = mousePointerPosition.target.transform.position.x;
        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(player.transform.position.y, mousePointerPosition.target.transform.position.y, (nextX - playerX) / dist);
        height = heightNum * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);
        movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        if (movePosition == mousePointerPosition.target.transform.position)
        {
            Destroy(gameObject);
            Destroy(shootingScript.spawnedMousePointer);
        }
    }
    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}
