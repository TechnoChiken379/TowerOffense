using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class projectileShrapnel : MonoBehaviour
{
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 0.25f;

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
    }
    public void determineDamage()
    {
        damageAmount = upgradeWeapons.damageAmountRoundShrapnel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyFunction>(out enemyFunction enemyComponent))
        {
            enemyComponent.ProcentDamageDealt(damageAmount);
            Destroy(gameObject);
        }
    }
}