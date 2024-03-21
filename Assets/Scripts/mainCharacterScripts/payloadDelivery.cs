using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class payloadDelivery : MonoBehaviour
{
    private float damageAmount = 5f;

    private float time;
    private float timeAlive = 4f;
    private float expandTime = 0.2f;

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

        size = Mathf.MoveTowards(size, maxSize, expandTime * 50 * Time.deltaTime);
        transform.localScale = new Vector2(size, size);
    }
    public void determineDamage()
    {
        damageAmount = upgradeWeapons.trebuchetPayloadDeliveryDamage;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<enemyArcherFunction>(out enemyArcherFunction enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount * Time.deltaTime);
        }
        if (other.TryGetComponent<enemyKnightFunction>(out enemyKnightFunction enemyComponent2))
        {
            enemyComponent2.DamageDealt(damageAmount * Time.deltaTime);
        }
        if (other.TryGetComponent<enemyRogueFunction>(out enemyRogueFunction enemyComponent3))
        {
            enemyComponent3.DamageDealt(damageAmount * Time.deltaTime);
        }
        if (other.TryGetComponent<enemyCannonFunction>(out enemyCannonFunction enemyComponent4))
        {
            enemyComponent4.DamageDealt(damageAmount * Time.deltaTime);
        }
    }
}