using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class enemySWallFunction : MonoBehaviour
{
    //health
    private float enemyHP, enemyMaxHP = 100f;

    //encampment
    public GameObject Encampment;


    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {

    }

    void Start()
    {
        enemyHP = enemyMaxHP;

        CalculateLevel();
    }

    void FixedUpdate()
    {
        IfDeadDie();
    }

    void IfDeadDie()
    {
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    void CalculateLevel()
    {
        Encampment.TryGetComponent<enemyEncampment>(out enemyEncampment enemyLvl);
        //enemyLvl.enemyLevel
        if (enemyLvl.enemyLevel == 1)
        {
            enemyMaxHP = 100f; //10X (1) weapon Dps
            enemyHP = 100f; //10X (1) weapon Dps
        }
        else if (enemyLvl.enemyLevel == 2)
        {
            enemyMaxHP = 200f; //10X (1) weapon Dps
            enemyHP = 200f; //10X (1) weapon Dps
        }
        else if (enemyLvl.enemyLevel == 3)
        {
            enemyMaxHP = 400f; //10X (1) weapon Dps
            enemyHP = 400f; //10X (1) weapon Dps
        }
        else if (enemyLvl.enemyLevel == 4)
        {
            enemyMaxHP = 800f; //10X (1) weapon Dps
            enemyHP = 800f; //10X (1) weapon Dps
        }
        else if (enemyLvl.enemyLevel >= 5)
        {
            enemyMaxHP = 1600f; //10X (1) weapon Dps
            enemyHP = 1600f; //10X (1) weapon Dps
        }
    }

    public void DamageDealt(float damageAmount)
    {
        enemyHP -= damageAmount;
        Encampment.TryGetComponent<enemyEncampment>(out enemyEncampment damageTaken);
        damageTaken.EncampmentDamaged();
    }

    public void ProcentDamageDealt(float damageAmount)
    {
        enemyHP -= enemyMaxHP * damageAmount;
        Encampment.TryGetComponent<enemyEncampment>(out enemyEncampment damageTaken);
        damageTaken.EncampmentDamaged();
    }
}
