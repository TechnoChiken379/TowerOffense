using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class projectileGrapeShot : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 0f;
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 0.25f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        determineDamageSpeed();
        MoveRandomDirection();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeAlive)
        {
            Destroy(gameObject);
        }
    }
    void MoveRandomDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * speed;
    }
    public void determineDamageSpeed()
    {
        damageAmount = upgradeWeapons.damageAmountRoundGrapeShot;
        speed = upgradeWeapons.roundSpeedGrapeShot;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<enemyArcherFunction>(out enemyArcherFunction enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyKnightFunction>(out enemyKnightFunction enemyComponent2))
        {
            enemyComponent2.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyRogueFunction>(out enemyRogueFunction enemyComponent3))
        {
            enemyComponent3.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyCannonFunction>(out enemyCannonFunction enemyComponent4))
        {
            enemyComponent4.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyTentFunction>(out enemyTentFunction enemyComponent5))
        {
            enemyComponent5.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyCrateFunction>(out enemyCrateFunction enemyComponent6))
        {
            enemyComponent6.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyWHouseFunction>(out enemyWHouseFunction enemyComponent7))
        {
            enemyComponent7.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemySHouseFunction>(out enemySHouseFunction enemyComponent8))
        {
            enemyComponent8.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemyWWallFunction>(out enemyWWallFunction enemyComponent9))
        {
            enemyComponent9.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<enemySWallFunction>(out enemySWallFunction enemyComponent10))
        {
            enemyComponent10.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent<bossFunction>(out bossFunction enemyComponent11))
        {
            enemyComponent11.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
    }
}