using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProjectileGrapeshot : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 0f;
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 0.25f;

    private bossFunction enemyScriptReference;
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
        damageAmount = bossFunction.damageAmountRoundGrapeShot;
        speed = bossFunction.roundSpeedGrapeShot;
    }

    public void SetEnemyScriptReference(bossFunction enemyScript)
    {
        enemyScriptReference = enemyScript;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("mainCharacter"))
        {
            mainCharacter.TakenDamageCalculation(damageAmount);
            mainCharacter.DetermineTotalRepairValue(damageAmount);

            if (upgradeArmor.deflectDamage)
            {
                enemyScriptReference.DamageDealt(damageAmount * (1f - upgradeArmor.deflectDamageNotTaken));
            }
        }
    }
}
