using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour
{
    //var
    public static int wood = 0;
    public static int stone = 0;
    public static int steel = 0;
    public static int gold = 0;

    //text
    public TMPro.TMP_Text woodText;
    public TMPro.TMP_Text stoneText;
    public TMPro.TMP_Text steelText;
    public TMPro.TMP_Text goldText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        steelText.text = steel.ToString();
        goldText.text = gold.ToString();

    }
}
