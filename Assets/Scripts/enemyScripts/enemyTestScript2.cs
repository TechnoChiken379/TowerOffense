using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript2 : MonoBehaviour
{
    private Transform player;

    const float projectileHeight = 1f;
    const float projectileSpeed = 1f;

    Vector3 startPos;
    Vector3 endPos;
    float fireLerp = 1;
    bool isFiring = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    void FireProjectile(Vector3 firePoint, Vector3 targetPos)
    {
        startPos = firePoint;
        endPos = targetPos;

        // Setting the fire lerp to 0 will begin the fire animation
        fireLerp = 0;
        isFiring = true;
    }

    void Update()
    {
        if (isFiring)
        {
            if (fireLerp < 1)
            {
                Vector3 newProjectilePos = CalculateTrajectory(startPos, endPos, fireLerp);
                transform.position = newProjectilePos;

                fireLerp += projectileSpeed * Time.deltaTime;
            }
            else
            {
                isFiring = false;
            }
        }
    }

    Vector3 CalculateTrajectory(Vector3 firePos, Vector3 targetPos, float t)
    {
        Vector3 linearProgress = Vector3.Lerp(firePos, targetPos, t);
        float perspectiveOffset = Mathf.Sin(t * Mathf.PI) * projectileHeight;

        Vector3 trajectoryPos = linearProgress + (Vector3.up * perspectiveOffset);
        return trajectoryPos;
    }
}