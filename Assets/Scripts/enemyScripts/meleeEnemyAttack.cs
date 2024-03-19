using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemyAttack : MonoBehaviour
{
    private GameObject player;

    private float speed = 7f;
    public static float enemyArrowDamageAmount = 5;

    private float time;
    private float timeAlive = 0.25f;

    private meleeEnemyFunction enemyScriptReference;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter");
    }
    void Update()
    {
        transform.rotation = LookAtTarget(player.transform.position - transform.position);
    }
    public static Quaternion LookAtTarget(Vector2 r) { return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg); }

    public void SetEnemyScriptReference(meleeEnemyFunction enemyScript)
    {
        enemyScriptReference = enemyScript;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            mainCharacter.TakenDamageCalculation(enemyArrowDamageAmount);
            mainCharacter.DetermineTotalRepairValue(enemyArrowDamageAmount);
            Destroy(gameObject);

            if (upgradeArmor.deflectDamage)
            {
                enemyScriptReference.DamageDealt(enemyArrowDamageAmount * (1f - upgradeArmor.deflectDamageNotTaken));
            }
        }
    }
}
