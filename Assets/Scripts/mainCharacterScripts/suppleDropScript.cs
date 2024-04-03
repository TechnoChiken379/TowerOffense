using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suppleDropScript : MonoBehaviour
{
    [SerializeField] public GameObject playerWayPoint;
    private GameObject projectileSpawn;
    private GameObject targetSpawn;
    public GameObject supplyShoot;
    public GameObject supplyDropParant;

    private float speed = 5f;
    public Vector3 movePosition;

    private float time = 0;
    private float timeAlive = 10f;
    private bool startTime = false;

    public Collider2D _collider;

    private Transform player;
    private float distanceToPlayer;

    private float supplyDistance = 7.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;

        calculateSpawnTarget();
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        SupplyMainCharacter();

        if (startTime)
        {
            time += Time.deltaTime;
            if (time >= timeAlive)
            {
                Destroy(supplyDropParant);
                Destroy(gameObject);
            }
        }

        projectileLine();

        transform.position = movePosition;

        if (Vector2.Distance(movePosition, targetSpawn.transform.position) < 0.1f)
        {
            _collider.enabled = true; startTime = true; Destroy(supplyShoot); Destroy(targetSpawn); Destroy(projectileSpawn);
        }
    }

    public void SupplyMainCharacter()
    {
        if (startTime && distanceToPlayer <= supplyDistance)
        {
            mainCharacter.totalCurrentHealth = Mathf.MoveTowards(mainCharacter.totalCurrentHealth, upgradeArmor.maxHealth, abilityScript.healthRegenerationSpeed * Time.deltaTime);
            mainCharacter.totalCurrentShieldHealth = Mathf.MoveTowards(mainCharacter.totalCurrentShieldHealth, upgradeArmor.maxShieldHealth, abilityScript.shieldRegenerationSpeed * Time.deltaTime);
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
