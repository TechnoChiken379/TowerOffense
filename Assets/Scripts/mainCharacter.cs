using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    //vars

    //Movement vars
    public float speed;
    private float moveX;
    private float moveY;

    //Health vars
    public float startingHealth;
    private float totalCurrentHealth;

    void Start()
    {
        //Movement speed
        speed = 4;

        //Starting health = Current health
        startingHealth = 100;
        totalCurrentHealth = startingHealth;
    }

    void FixedUpdate()
    {
        Movement();
    }

















    void Movement()
    {
        //Movement
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0);
    }
}
