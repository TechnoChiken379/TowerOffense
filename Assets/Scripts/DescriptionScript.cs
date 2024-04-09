using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionScript : MonoBehaviour
{
    private string itemDescription;
    private string itemName;
    private string itemCost;
    private Vector2 buttonPos;

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }

    public void Archers()
    {
        itemName = "Archers Upgrade";
        itemCost = "100 wood, 100 steel, 100 stone";
        itemDescription = "WORKS!";
    }

    public void Cannons()
    {
        itemName = "CANNONS Upgrade";
        itemCost = "100 wood, 100 steel, 100 stone";
        itemDescription = "WORKS!";
    }

    public void OnCursorEnter()
    {
        DescriptionManager.Instance.DisplayItemInfo(itemName, itemCost, itemDescription, buttonPos);
    }

    public void OnCursorExit()
    {
        DescriptionManager.Instance.DestroyItemInfo();
    }
}
