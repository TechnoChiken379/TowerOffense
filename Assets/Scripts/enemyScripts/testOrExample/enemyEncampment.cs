using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEncampment : MonoBehaviour
{
    private Transform player;
    private float distanceToPlayer;

    public bool encampmentDamaged = false;

    public float time;
    public float replaceTime = 60f;

    public GameObject enemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        ReplaceEncampment();
    }

    private void ReplaceEncampment()
    {
        if (encampmentDamaged && distanceToPlayer > 20f)
        {
            time += Time.deltaTime;
        }
        if (time >= replaceTime)
        {
            GameObject nextEnemyEncampment = Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void EncampmentDamaged()
    {
        encampmentDamaged = true;
    }
}
