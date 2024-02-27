using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class projectile : MonoBehaviour
{
    [SerializeField] public GameObject playerWayPoint;
    private GameObject projectileSpawn;
    private GameObject targetSpawn;

    private Vector2 worldMousePosition;
    private Vector2 mousePosition;

    public float speed = 7f;
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
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        projectileSpawn = Instantiate(playerWayPoint, transform.position, Quaternion.identity);
        targetSpawn = Instantiate(playerWayPoint, worldMousePosition, Quaternion.identity);
    }

    void Update()
    {
        ////var playerX = position.x GameObject with tag("mainCharacter")
        //playerX = projectileSpawn.transform.position.x;

        ////var targetX = GameObject mousePointer position.x
        //targetX = targetSpawn.transform.position.x;

        ////dist = Distance = target.x - player.x
        //dist = targetX - playerX;

        ////nextX = position a naar position b * (speed?)
        ////rechte lijn naar
        //nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);

        ////Weet ik niet veel van af
        ////Linearly interpolates = ga van a naar b door (MoveTowards - Player.x Position gedeeld door distance)
        //baseY = Mathf.Lerp(projectileSpawn.transform.position.y, targetSpawn.transform.position.y, (nextX - playerX) / dist);

        ////Hoe hoog dat het object kan
        ////Hoogte = een int * (MoveTowards - Player.x) * (MoveTowards - Target.x) gedeeld door (-0.25 * Distance * Disrance) (geen idee waarom die 0.25)
        //height = heightNum * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

        ////Ga naar nieuwe vector 3 positie
        ////X = MoveTowards
        ////Y = baseY (Lerp(Linearly interpolates))
        ////Z = current gameObject z.position
        //movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        ////Verandert de rotation naar de methode LookAtTarget(Move position - de current gameObject. position)
        //transform.rotation = LookAtTarget(movePosition - transform.position);

        ////Verandert de position van de current gameObject naar de nieuwe positie (movePosition)
        //transform.position = movePosition;

        ////If gameObject (= object where this script is on) is on target position (mouse pointer)
        //if (movePosition == targetSpawn.transform.position)
        //{
        //    //Destroy mousePointer game object first
        //    //Destroy(shootingScript.spawnedMousePointer);
        //    //Destroy current gameObject
        //    Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn);
        //}

        playerX = projectileSpawn.transform.position.x;
        targetX = targetSpawn.transform.position.x;

        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(projectileSpawn.transform.position.y, targetSpawn.transform.position.y, (nextX - playerX) / dist);
        height = heightNum * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        if (movePosition == targetSpawn.transform.position) { Destroy(gameObject); Destroy(targetSpawn); Destroy(projectileSpawn); }
    }

    //dunno about this shit = look at target
    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}