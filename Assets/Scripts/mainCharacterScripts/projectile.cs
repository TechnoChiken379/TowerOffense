using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class projectile : MonoBehaviour
{
    //public GameObject player;
    //public GameObject target;
    //public float speed = 10f;
    //public float launchHeight = 2;
    //public Vector3 movePosition;
    //private float playerX;
    //private float targetX;
    //private float nextX;
    //private float dist;
    //private float baseY;
    //private float height;

    private GameObject player;

    private float playerX;
    private float playerY;
    private Vector3 target;
    private Vector3 movePosition;
    private Vector3 dir;
    private Vector3 mousePointerDir;
    private GameObject mousePointer;
    public GameObject mousePointerPrefab;
    private float targetX;
    private float targetY;
    private float baseY;
    private float distance;
    private float moveTowards;
    private float height;
    private float speed = 20;
    private float launchHeight = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("archer");
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        mousePointer = Instantiate(mousePointerPrefab);
        mousePointer.transform.position = mousePointerDir;
        ProjectileTrajectory();

    }
    void Update()
    {

        //playerX = player.transform.position.x;
        //targetX = target.transform.position.x;
        //dist = targetX - playerX;
        ////moves from a to b * t (amount of time (speed))
        //nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        ////the arch while traveling + the height it should go
        //baseY = Mathf.Lerp(player.transform.position.y, target.transform.position.y, (nextX - playerX) / dist);
        //height = launchHeight * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

        //movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        //transform.rotation = LookAtTarget(movePosition - transform.position);
        //transform.position = movePosition;
        //if (movePosition == target.transform.position)
        //{
        //    Destroy(gameObject);
        //}
    }

    public void ProjectileTrajectory()
    {
        //getting the player position values and putting them in floats
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

        //setting the values of the mouse position in floats
        target = dir;
        targetX = target.x;
        targetY = target.y;

        distance = playerX - (mousePointerDir.x);
        moveTowards = Mathf.MoveTowards(playerX, (mousePointerDir.x), speed * Time.deltaTime);
        baseY = Mathf.Lerp(playerY, (mousePointerDir.y), (moveTowards - playerX) / distance);
        height = launchHeight * (moveTowards - playerX) * (moveTowards - (mousePointerDir.x)) / (-0.25f * distance * distance);

        movePosition = new Vector3(moveTowards, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        if (movePosition == dir)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}
