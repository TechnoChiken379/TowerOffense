using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterMovement : MonoBehaviour
{
    public float speed;
    private float moveX;
    private float moveY;

    void Start()
    {
        speed = 4;
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0);
    }
}
