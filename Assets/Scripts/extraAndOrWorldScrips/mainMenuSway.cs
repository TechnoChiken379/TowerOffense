using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuSway : MonoBehaviour
{
    Vector2 startPosition;

    [SerializeField] int moveSpeedModifier;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Vector2 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float posX = Mathf.Lerp(transform.position.x, startPosition.x + (pz.x / moveSpeedModifier), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, startPosition.y + (pz.y / moveSpeedModifier), 2f * Time.deltaTime);
        Debug.Log(pz.x);

        transform.position = new Vector3(posX, posY, 0);
    }
}
