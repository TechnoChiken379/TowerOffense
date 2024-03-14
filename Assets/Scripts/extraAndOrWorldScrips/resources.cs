using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour, IDataPersistance
{
    //var
    public static float woodAmount = 0;
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

    public void LoadData(GameData data)
    {
        woodAmount = data.woodAmount;
    }

    public void SaveData(ref GameData data)
    {
        data.woodAmount = woodAmount;
    }

    void Update()
    {
        showedWood = (int)Mathf.Round(woodAmount);
        showedStone = (int)Mathf.Round(stone);
        showedSteel = (int)Mathf.Round(steel);
        showedGold = (int)Mathf.Round(gold);

        woodText.text = showedWood.ToString();
        stoneText.text = showedStone.ToString();
        steelText.text = showedSteel.ToString();
        goldText.text = showedGold.ToString();
    }
}
