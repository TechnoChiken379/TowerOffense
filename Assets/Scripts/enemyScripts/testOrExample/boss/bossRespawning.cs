using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossRespawning : MonoBehaviour
{
    private Transform player;
    private float distanceToPlayer;
    private float renderDistance = 25f;

    public float time;
    private float replaceTime = 300f;

    public GameObject enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        ReplaceEncampment();
        Render();
    }
    private void ReplaceEncampment()
    {
        if (transform.childCount == 0 && distanceToPlayer > 20f)
        {
            time += Time.deltaTime;
        }
        if (time >= replaceTime)
        {
            GameObject nextboss = Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void Render()
    {
        if (distanceToPlayer > renderDistance)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
