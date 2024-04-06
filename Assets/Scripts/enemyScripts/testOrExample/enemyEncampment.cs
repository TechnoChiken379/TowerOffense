using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Buffers.Text;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class enemyEncampment : MonoBehaviour
{
    private Transform player;
    private float distanceToPlayer;

    public bool encampmentDamaged = false;

    public float time;
    private float replaceTime = 300f;

    public int enemyLevel = 1;

    private float renderDistance = 30f;

    public GameObject enemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        ReplaceEncampment(); RepairEncampment();
        Render();
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

    public void RepairEncampment()
    {
        if (encampmentDamaged && mainCharacter.totalCurrentHealth <= 0) 
        {
            time = replaceTime + 1;
        }
    }
}
