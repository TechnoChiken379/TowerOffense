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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyFunction>(out enemyFunction enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
    }
}