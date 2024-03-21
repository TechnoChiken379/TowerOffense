using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenManager : MonoBehaviour
{
    public Animator DeathScreenAnimator;

    private float timer = 0f;
    private bool deathManagerState0 = false;
    private bool deathManagerState1 = false;
    private bool deathManagerState2 = false;
    private bool deathManagerState3 = false;
    private bool deathManagerIsDead = false;
    private bool deathManagerMainMenu = false;
    private bool deathManagerLoadLastSave = false;
    private bool deathAnimation = false;

    public GameObject DeathScreenBackGround;

    void Update()
    {
        if (mainCharacter.totalCurrentHealth <= 0 && deathManagerState1 == false && deathManagerState0 == false)
        {
            deathManagerIsDead = true;
            deathManagerMainMenu = false;
            deathManagerLoadLastSave = false;
            DeathManager();
        }
        else if (deathManagerMainMenu == true)
        {
            deathManagerIsDead = false;
            deathManagerMainMenu = true;
            deathManagerLoadLastSave = false;
            deathManagerState1 = false;
            deathManagerState2 = false;
            deathManagerState3 = false;
            DeathManager();
        }
        else if (deathManagerLoadLastSave == true)
        {
            deathManagerIsDead = false;
            deathManagerMainMenu = false;
            deathManagerLoadLastSave = true;
            deathManagerState1 = false;
            deathManagerState2 = false;
            deathManagerState3 = false;
            DeathManager();
        }
    }

    private void DeathManager()
    {
        timer += Time.deltaTime;
        if (deathManagerIsDead == true) { DeathScreenAnimator.SetBool("Is Dead", true); }

        if (deathManagerState2 == false)
        {
            timer = 0;
            deathManagerState2 = true;
        }
        if (timer >= 4 && deathManagerState3 == false)
        {
            if (deathManagerIsDead == true)
            {
                SceneManager.LoadScene("DeathScreen");
                deathManagerIsDead = false;
                deathAnimation = true;
                if (deathAnimation == true)
                {
                    DeathScreenAnimator.Play("DeathMenuAnimation");
                    deathAnimation = false;
                }
            }
            else if (deathManagerMainMenu == true) { SceneManager.LoadScene("MainMenu"); deathManagerMainMenu = false; }
            else if (deathManagerLoadLastSave == true) { SceneManager.LoadScene("MainMenu"); deathManagerLoadLastSave = false; }
            deathManagerState3 = true;
            deathManagerState1 = true;
        }
    }

    public void MainMenuButton()
    {
        deathManagerMainMenu = true;
    }

    public void LoadLastSave()
    {
        deathManagerLoadLastSave = true;
    }
}