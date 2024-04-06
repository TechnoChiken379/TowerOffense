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


    //private GameObject[] enemyCamps;
    //private Transform enemyCampsTransform;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        //FindClosestEnemyCamp();
    }
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        ReplaceEncampment();
        Render();
    }

    //void FindClosestEnemyCamp()
    //{
    //    enemyCamps = GameObject.FindGameObjectsWithTag("EnemyCamp");

    //    enemyCampsTransform = GetClosestEnemy(enemyCamps);
    //}

    //Transform GetClosestEnemy(GameObject[] enemieCampArray)
    //{
    //    float closestDistance = Mathf.Infinity;

    //    foreach (GameObject enemy in enemieCampArray)
    //    {
    //        if (enemy != gameObject)
    //        {
    //            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

    //            if (distanceToEnemy < closestDistance)
    //            {
    //                closestDistance = distanceToEnemy;
    //                enemyCampsTransform = enemy.transform;
    //            }
    //        }
    //    }
    //    return enemyCampsTransform;
    //}

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
}
