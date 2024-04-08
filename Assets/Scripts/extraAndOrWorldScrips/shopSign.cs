using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopSign : MonoBehaviour
{
    public GameObject shopSignObject;
    private Transform player;
    public float distanceToPlayer;
    private float showSign = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= showSign)
        {
            shopSignObject.SetActive(true);
        } else
        {
            shopSignObject.SetActive(false);
        }
    }
}
