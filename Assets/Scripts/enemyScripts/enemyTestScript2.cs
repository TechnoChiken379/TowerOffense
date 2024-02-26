using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyTestScript2 : MonoBehaviour
{
    public AnimationCurve curve;

    //[SerializeField] private float duration = 1.0f;
    //[SerializeField] private float maxHeightY = 3.0f;
    private GameObject player;
    private GameObject enemy;
    public GameObject target;
    public GameObject targetSpawn;

    public float speed = 5f;
    public float heightNum = 0.5f;
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
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        targetSpawn = Instantiate(target, player.transform.position, Quaternion.identity);
        Destroy(targetSpawn, 2);
    }

    void Update()
    {
        enemyX = enemy.transform.position.x;
        targetX = target.transform.position.x;

        dist = targetX - enemyX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(transform.position.y, target.transform.position.y, (nextX - enemyX) / dist);
        height = 2 * (nextX - enemyX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition; if (movePosition == target.transform.position) { Destroy(gameObject); }
    }
    public static Quaternion LookAtTarget(Vector2 r){ return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }


}
