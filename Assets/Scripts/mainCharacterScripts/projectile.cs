using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class projectile : MonoBehaviour
{
    public GameObject player;
    [SerializeField]public GameObject target;
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
        player = GameObject.FindGameObjectWithTag("mainCharacter");
    }

    void Update()
    {
        //var playerX = position.x GameObject with tag("mainCharacter")
        playerX = player.transform.position.x;

        //var targetX = GameObject mousePointer position.x
        targetX = mousePointerPosition.target.transform.position.x;

        //dist = Distance = target.x - player.x
        dist = targetX - playerX;

        //nextX = position a naar position b * (speed?)
        //rechte lijn naar
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);

        //Weet ik niet veel van af
        //Linearly interpolates = ga van a naar b door (MoveTowards - Player.x Position gedeeld door distance)
        baseY = Mathf.Lerp(player.transform.position.y, mousePointerPosition.target.transform.position.y, (nextX - playerX) / dist);

        //Hoe hoog dat het object kan
        //Hoogte = een int * (MoveTowards - Player.x) * (MoveTowards - Target.x) gedeeld door (-0.25 * Distance * Disrance) (geen idee waarom die 0.25)
        height = heightNum * (nextX - playerX) * (nextX - targetX) / (-0.25f * dist * dist);

        //Ga naar nieuwe vector 3 positie
        //X = MoveTowards
        //Y = baseY (Lerp(Linearly interpolates))
        //Z = current gameObject z.position
        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        //Verandert de rotation naar de methode LookAtTarget(Move position - de current gameObject. position)
        transform.rotation = LookAtTarget(movePosition - transform.position);

        //Verandert de position van de current gameObject naar de nieuwe positie (movePosition)
        transform.position = movePosition;

        //If gameObject (= object where this script is on) is on target position (mouse pointer)
        if (movePosition ==mousePointerPosition.target.transform.position)
        {
            //Destroy mousePointer game object first
            Destroy(shootingScript.spawnedMousePointer);
            //Destroy current gameObject
            Destroy(gameObject);
        }
    }

    //dunno about this shit = look at target
    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}