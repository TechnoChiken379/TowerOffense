using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suppleDropScript : MonoBehaviour
{
    [SerializeField] public GameObject playerWayPoint;
    private GameObject projectileSpawn;
    private GameObject targetSpawn;
    public GameObject supplyShoot;

    private float speed = 5f;
    public Vector3 movePosition;

    private float time;
    private float timeAlive = 15f;

    public Collider2D _collider;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;

        calculateSpawnTarget();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeAlive)
        {
            Destroy(gameObject);
        }

        projectileLine();

        transform.position = movePosition;

        if (Vector2.Distance(movePosition, targetSpawn.transform.position) < 0.1f)
        {
            _collider.enabled = true; Destroy(supplyShoot); Destroy(targetSpawn); Destroy(projectileSpawn);
        }
    }

    #region movement
    public void projectileLine()
    {
        Vector3 direction = (targetSpawn.transform.position - transform.position).normalized;
        movePosition = transform.position + direction * speed * Time.deltaTime;
    }

    public void calculateSpawnTarget()
    {
        Vector2 targetLocation = new Vector2 (transform.position.x, transform.position.y - abilityScript.SupplyDrophight);
        projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
        targetSpawn = Instantiate(playerWayPoint, targetLocation, Quaternion.identity);
    }
    #endregion
}
