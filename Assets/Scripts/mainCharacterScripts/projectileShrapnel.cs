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
        if (other.gameObject.TryGetComponent<enemyFunction>(out enemyFunction enemyComponent))
        {
            enemyComponent.ProcentDamageDealt(damageAmount);
        }
    }
}