using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public static DescriptionManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DisplayItemInfo(string itemName, string itemCost, string itemDescription, Vector2 buttonPos)
    {
        if (currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }

        buttonPos.x = 5.5f;
        buttonPos.y = -4;

        currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentItemInfo.GetComponent<ItemInfoScript>().SetUp(itemName, itemCost, itemDescription);
    }

    public void DestroyItemInfo()
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }
}
