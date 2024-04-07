using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProjectileShrapnel : MonoBehaviour
{
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 0.2f;

    private float size = 0.9f;
    private float maxSize = 1.5f;

    private bossFunction enemyScriptReference;
    void Start()
    {
        determineDamage();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeAlive)
        {
            Destroy(gameObject);
        }

        size = Mathf.MoveTowards(size, maxSize, timeAlive * 50 * Time.deltaTime);
        transform.localScale = new Vector2(size, size);
    }
    public void determineDamage()
    {
        damageAmount = bossFunction.damageAmountRoundShrapnel;
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
