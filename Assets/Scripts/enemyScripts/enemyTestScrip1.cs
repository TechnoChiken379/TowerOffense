using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyTestScrip1 : MonoBehaviour
{
    private Transform player;

    private float speed = 2f;
    private float closeEnough = 3f;
    private float toClose = 2f;
    private float timer = 0f;
    private float moveTime = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer >= closeEnough)
        {
            timer += Time.deltaTime;
            if (timer >= moveTime)
            {
                transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
            }
        }
        else if (distanceToPlayer <= toClose)
        {
            timer += Time.deltaTime;
            if (timer >= moveTime)
            {
                transform.Translate((player.position - transform.position).normalized * Time.deltaTime * -speed);
            }
        }
        else
        {
            timer = 0f;
        }
    }
}
