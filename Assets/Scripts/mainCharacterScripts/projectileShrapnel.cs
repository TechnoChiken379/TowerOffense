using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class projectileShrapnel : MonoBehaviour
{
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 0.2f;

    private float size = 0.9f;
    private float maxSize = 1.5f;

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
        damageAmount = upgradeWeapons.damageAmountRoundShrapnel;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<enemyArcherFunction>(out enemyArcherFunction enemyComponent))
        {
            enemyComponent.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyKnightFunction>(out enemyKnightFunction enemyComponent2))
        {
            enemyComponent2.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyRogueFunction>(out enemyRogueFunction enemyComponent3))
        {
            enemyComponent3.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyCannonFunction>(out enemyCannonFunction enemyComponent4))
        {
            enemyComponent4.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyTentFunction>(out enemyTentFunction enemyComponent5))
        {
            enemyComponent5.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyCrateFunction>(out enemyCrateFunction enemyComponent6))
        {
            enemyComponent6.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyWHouseFunction>(out enemyWHouseFunction enemyComponent7))
        {
            enemyComponent7.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemySHouseFunction>(out enemySHouseFunction enemyComponent8))
        {
            enemyComponent8.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemyWWallFunction>(out enemyWWallFunction enemyComponent9))
        {
            enemyComponent9.ProcentDamageDealt(damageAmount);
        }
        if (other.gameObject.TryGetComponent<enemySWallFunction>(out enemySWallFunction enemyComponent10))
        {
            enemyComponent10.ProcentDamageDealt(damageAmount);
        }
    }
}