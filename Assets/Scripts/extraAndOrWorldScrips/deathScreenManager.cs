using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenManager : MonoBehaviour
{
    public Animator DeathScreenAnimator;

    private float timer = 0f;
    private float timer2 = 0f;
    private bool deathManagerState1 = false;
    private bool deathManagerState2 = false;
    private bool deathManagerState3 = false;
    private bool deathManagerIsDead = false;
    private bool deathAnimation = false;

    public static bool saveOnDeath = false;

    public GameObject DeathScreenBackGround;

    void Update()
    {
        if (mainCharacter.totalCurrentHealth <= 0 && deathManagerState1 == false)
        {
            DeathManager();
        }
    }

    private void DeathManager()
    {
        timer += Time.deltaTime;
        DeathScreenAnimator.SetBool("Is Dead", true);

        if (deathManagerState2 == false)
        {
            timer = 0;
            deathManagerState2 = true;
            resources.woodAmount /= 2;
            resources.stoneAmount /= 2;
            resources.steelAmount /= 2;
            resources.goldAmount /= 2;
        }
        if (timer >= 2 && deathManagerState3 == false)
        {
            if (deathManagerIsDead == false)
            {
                deathManagerIsDead = true;
                deathAnimation = true;

                saveOnDeath = true;
                DataPersistanceManager.saveGameBool = true;
                if (deathAnimation == true)
                {
                    DeathScreenAnimator.Play("DeathMenuAnimation");
                    deathAnimation = false;
                }
            }
            deathManagerState3 = true;
            deathManagerState1 = true;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RebuildButton()
    {
        SceneManager.LoadScene("tilemapTesting");
    }
}