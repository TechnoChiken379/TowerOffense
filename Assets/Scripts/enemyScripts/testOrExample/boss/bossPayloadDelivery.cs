using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPayloadDelivery : MonoBehaviour
{
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 4f;
    private float expandTime = 0.2f;

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

        size = Mathf.MoveTowards(size, maxSize, expandTime * 50 * Time.deltaTime);
        transform.localScale = new Vector2(size, size);
    }
    public void determineDamage()
    {
        damageAmount = bossFunction.trebuchetPayloadDeliveryDamage;
    }
    public void SetEnemyScriptReference(bossFunction enemyScript)
    {
        enemyScriptReference = enemyScript;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("mainCharacter"))
        {
            mainCharacter.TakenDamageCalculation(damageAmount * Time.deltaTime);
            mainCharacter.DetermineTotalRepairValue(damageAmount * Time.deltaTime);

            if (upgradeArmor.deflectDamage)
            {
                enemyScriptReference.DamageDealt(damageAmount * (1f - upgradeArmor.deflectDamageNotTaken));
            }
        }
    }
}
