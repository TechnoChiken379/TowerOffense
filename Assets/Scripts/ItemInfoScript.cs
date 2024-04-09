using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfoScript : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemCost;
    public TMP_Text itemDescription;

    public void SetUp(string name, string cost, string description)
    {
        itemName.text = name;
        itemCost.text = cost;
        itemDescription.text = description;
    }
}
