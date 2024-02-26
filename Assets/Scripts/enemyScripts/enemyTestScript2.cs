using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript2 : MonoBehaviour
{
    private GameObject enemyTest1;
    [SerializeField] public GameObject target;
    public float speed = 10f;
    public float heightNum = 0.5f;
    public Vector3 movePosition;
    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;

    void Start()
    {
        enemyTest1 = GameObject.FindGameObjectWithTag("Enemy");
    }
}