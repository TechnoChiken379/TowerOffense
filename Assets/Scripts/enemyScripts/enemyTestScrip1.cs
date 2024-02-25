using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyTestScrip1 : MonoBehaviour
{
    public string state = "State.Idle";

    private Transform player;
    public float distanceToPlayer;

    private float speed = 2f;
    private float closeEnough = 3f;
    private float toClose = 2f;
    private float timer = 0f;
    private float moveTime = 0.1f;
    private float engageDistance = 10f;

    //attack
    public float rotationCheck;
    private float angle;

    private GameObject spawnedBullet;
    public static GameObject spawnedMousePointer;
    public GameObject mousePointer;
    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    private float timerArchers;
    private float canFireArchers = 0.5f;
    public GameObject arrow;
    public Transform arrowSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        StateConditions();
        ExecuteConditions();
    }

    public void StateConditions()
    {
        if (distanceToPlayer <= engageDistance)
        {

            if (distanceToPlayer >= closeEnough)
            {
                state = "State.Move";
            }
            else if (distanceToPlayer <= toClose)
            {
                state = "State.Retreat";
            }
            else
            {
                timer = 0f;
            }

            if (distanceToPlayer < closeEnough && distanceToPlayer > toClose)
            {
                state = "State.attack";
                timerArchers += Time.deltaTime;
            }
        } else
        {
            state = "State.Idle";
        }
    }
    public void ExecuteConditions()
    {
        switch (state)
        {
            case "State.Idle":
                Debug.Log("State.Idle");
                break;
            case "State.attack":
                Debug.Log("State.Attack");
                Attack();
                break;
            case "State.Move":
                Move();
                break;
            case "State.Retreat":
                Retreat();
                break;
            default: 
                
            break;
        }
    }
    public void Move()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
        }
    }
    public void Retreat()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * -speed);
        }
    }
    public void Attack()
    {
        if (timerArchers >= canFireArchers)
        {
            spawnedBullet = arrow;
            spawnedMousePointer = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
            spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

            timerArchers = 0f;
        }
    }
}
