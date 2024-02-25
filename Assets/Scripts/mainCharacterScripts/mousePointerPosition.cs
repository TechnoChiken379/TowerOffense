using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointerPosition : MonoBehaviour
{
    public static GameObject target;
    private float b;

    void Start()
    {
        float.TryParse(gameObject.name, out b);
        target = gameObject;
    }

    void Update() 
    {

    }
}
