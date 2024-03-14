using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.Unicode;

public class projectileGrapeShot : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 1f;
    private float damageAmount = 5f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        determineDamageSpeed();
        MoveRandomDirection();
    }

    void Update()
    { 
    
    }
    void MoveRandomDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = transform.position * randomDirection * speed;
    }
    public void determineDamageSpeed()
    {
        damageAmount = upgradeWeapons.damageAmountRoundGrapeShot;
        speed = upgradeWeapons.roundSpeedGrapeShot;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyTestScrip1>(out enemyTestScrip1 enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount);
            Destroy(gameObject);
        }
    }
}