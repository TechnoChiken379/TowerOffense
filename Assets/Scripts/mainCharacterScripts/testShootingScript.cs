using UnityEngine;

public class LineAndArrowRotation : MonoBehaviour
{
    public Transform target; // Reference to the target GameObject
    public GameObject arrowPrefab; // Prefab of the arrow object
    public float speed = 5f; // Speed at which the arrow rotates

    private LineRenderer lineRenderer;
    private GameObject arrow;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Two points to create a line

        // Instantiate the arrow at the start position
        arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        arrow.transform.rotation = LookAtTarget(target.position - transform.position);
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;

            // Set the positions of the line renderer
            lineRenderer.SetPosition(0, transform.position); // Start position
            lineRenderer.SetPosition(1, transform.position + direction); // End position

            // Rotate the arrow towards the end of the line
            if (arrow != null)
            {
                float step = speed * Time.deltaTime;
                arrow.transform.position = Vector3.MoveTowards(arrow.transform.position, target.position, step);
                
            }
        }
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}
