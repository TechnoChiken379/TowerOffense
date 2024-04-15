using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour, IDataPersistance
{
    //var
    public static float woodAmount = 0;
    public static float stoneAmount = 0;
    public static float steelAmount = 0;
    public static float goldAmount = 0;

    public static int showedWood = 0;
    public static int showedStone = 0;
    public static int showedSteel = 0;
    public static int showedGold = 0;

    //text
    public TMPro.TMP_Text woodText;
    public TMPro.TMP_Text stoneText;
    public TMPro.TMP_Text steelText;
    public TMPro.TMP_Text goldText;

    /*void Start()
    {
        
    } */

    public void LoadData(GameData data)
    {
        woodAmount = data.woodAmount;
        stoneAmount = data.stoneAmount;
        steelAmount = data.steelAmount;
        goldAmount = data.goldAmount;
    }

    public void SaveData(ref GameData data)
    {
        data.woodAmount = woodAmount;
        data.stoneAmount = stoneAmount;
        data.steelAmount = steelAmount;
        data.goldAmount = goldAmount;
    }

    void Update()
    {
        showedWood = (int)Mathf.Round(woodAmount);
        showedStone = (int)Mathf.Round(stoneAmount);
        showedSteel = (int)Mathf.Round(steelAmount);
        showedGold = (int)Mathf.Round(goldAmount);

        woodText.text = showedWood.ToString();
        stoneText.text = showedStone.ToString();
        steelText.text = showedSteel.ToString();
        goldText.text = showedGold.ToString();
    }
}
