using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyTestScrip1 : MonoBehaviour
{
    public string state = "State.Idle"; //what does the enemy want to do

    private Transform player;
    public float distanceToPlayer;

    private float speed = 2f; //movement speed
    private float closeEnough = 3f; //how close does the enemy want to get
    private float toClose = 2f; //how far does the enemy want to stay away from player
    private float timer = 0f; //timer to keep track of time before moving
    private float moveTime = 0.1f; //time to start moving
    private float engageDistance = 10f; //at what distance should the enemy start going to the player

    ////attack (work in progress)
    //public float rotationCheck;
    //private float angle;

    //private GameObject spawnedBullet;
    //public static GameObject spawnedMousePointer;
    //public GameObject mousePointer;
    //private Vector2 worldMousePosition;
    //private Vector2 mousePosition;

    //private float timerArchers;
    //private float canFireArchers = 0.5f;
    //public GameObject arrow;
    //public Transform arrowSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        StateConditions(); //check what should the enemy should want to do
        ExecuteConditions(); //try to do what the enemy should want to do
    }

    public void StateConditions()
    {
        if (distanceToPlayer <= engageDistance) //check if the enemy is within range of the player
        {

            if (distanceToPlayer >= closeEnough) //move to the player if far away
            {
                state = "State.Move";
            }
            else if (distanceToPlayer <= toClose) //move away from player if to close
            {
                state = "State.Retreat";
            }
            else //reset move time if within range to attack player
            {
                timer = 0f;
            }

            if (distanceToPlayer < closeEnough && distanceToPlayer > toClose) //attack player if within the right range to do so
            {
                state = "State.attack";
                //timerArchers += Time.deltaTime;
            }
        } else //idle if the enemy is out of range of the player
        {
            state = "State.Idle";
        }
    }
    public void ExecuteConditions()
    {
        switch (state)
        {
            case "State.Idle": //idle 
                Debug.Log("State.Idle");
                break;
            case "State.attack":
                Debug.Log("State.Attack");
                //Attack();
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
    //public void Attack()
    //{
    //    if (timerArchers >= canFireArchers)
    //    {
    //        spawnedBullet = arrow;
    //        spawnedMousePointer = Instantiate(mousePointer, worldMousePosition, Quaternion.Euler(0, 0, angle));
    //        spawnedBullet = Instantiate(arrow, arrowSpawnPoint.position, Quaternion.Euler(0, 0, angle));

    //        timerArchers = 0f;
    //    }
    //}
}
