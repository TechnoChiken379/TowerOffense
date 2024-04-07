using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findNearestShop : MonoBehaviour
{
    private GameObject[] shops;
    public static Transform closestShop;

    void Start()
    {
        
    }

    void Update()
    {
        FindClosestShops();
        Debug.Log(closestShop.transform.position);
    }

    void FindClosestShops()
    {
        shops = GameObject.FindGameObjectsWithTag("shop");

        closestShop = GetClosestEnemy(shops);
    }

    Transform GetClosestEnemy(GameObject[] enemiesArray)
    {
        float closestDistance = Mathf.Infinity;

        foreach (GameObject shop in enemiesArray)
        {
            if (shop != gameObject)
            {
                float distanceToShop = Vector2.Distance(transform.position, shop.transform.position);

                if (distanceToShop < closestDistance)
                {
                    closestDistance = distanceToShop;
                    closestShop = shop.transform;
                }
            }
        }
        return closestShop;
    }
}
