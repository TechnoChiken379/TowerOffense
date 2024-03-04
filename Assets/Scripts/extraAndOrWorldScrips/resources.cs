using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour
{
    //var
    public static float wood = 0;
    public static float stone = 0;
    public static float steel = 0;
    public static float gold = 0;

    public int showedWood = 0;
    public int showedStone = 0;
    public int showedSteel = 0;
    public int showedGold = 0;

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
        showedWood = (int)Mathf.Round(wood);
        showedStone = (int)Mathf.Round(stone);
        showedSteel = (int)Mathf.Round(steel);
        showedGold = (int)Mathf.Round(gold);

        woodText.text = showedWood.ToString();
        stoneText.text = showedStone.ToString();
        steelText.text = showedSteel.ToString();
        goldText.text = showedGold.ToString();
    }
}
