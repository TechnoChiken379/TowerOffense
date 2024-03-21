using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKnightProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    private float speed = 5f;
    public static float enemyProjectileDamageAmount = 10;

    private float time;
    private float timeAlive = 0.15f;

    private enemyKnightFunction enemyScriptReference;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter");
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.rotation = LookAtTarget(player.transform.position - transform.position);

        Move();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeAlive)
        {
            Destroy(gameObject);
        }
    }
    public static Quaternion LookAtTarget(Vector2 r) { return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }

    public void Move()
    {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        rb.velocity = directionToPlayer * speed;
    }

    public void DetermineDamage(float damage)
    {
        enemyProjectileDamageAmount = damage;
    }

    public void SetEnemyScriptReference(enemyKnightFunction enemyScript)
    {
        enemyScriptReference = enemyScript;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("mainCharacter"))
        {
            mainCharacter.TakenDamageCalculation(enemyProjectileDamageAmount);
            mainCharacter.DetermineTotalRepairValue(enemyProjectileDamageAmount);
            Destroy(gameObject);

            if (upgradeArmor.deflectDamage)
            {
                enemyScriptReference.DamageDealt(enemyProjectileDamageAmount * (1f - upgradeArmor.deflectDamageNotTaken));
            }
        }
    }
}
