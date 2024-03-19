using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenAnimation : MonoBehaviour
{
    public Animator DeathScreenAnimator;

    private float timer = 0f;
    private bool Switch = false;

    public GameObject DeathScreenBackGround;

    void Update()
    {
        DeathManager();
        timer += Time.deltaTime;
        if (timer >= 4 && Switch == true)
        {
            SceneManager.LoadScene("MainMenu");
            Switch = false;
        }
    }

    private void DeathManager()
    {

        if (mainCharacter.totalCurrentHealth <= 0 && !(DeathScreenAnimator.GetBool("MainMenu") == true || DeathScreenAnimator.GetBool("LastSave") == true))
        {
            DeathScreenAnimator.SetBool("Is Dead", true);
            DeathScreenBackGround.SetActive(true);
        }
        else
        {
            DeathScreenAnimator.SetBool("Is Dead", false);
        }
        if (DeathScreenAnimator.GetBool("MainMenu") == true || DeathScreenAnimator.GetBool("LastSave") == true)
        {
            DeathScreenAnimator.SetBool("Is Dead", false);
        }
    }

    public void LoadLastSave()
    {
        Switch = true;
        timer = 0f;
        DeathScreenAnimator.SetBool("LastSave", true);
        //DeathScreenAnimator.SetBool("Is Dead", false);
    }

    public void MainMenu()
    {
        Switch = true;
        timer = 0f;
        DeathScreenAnimator.SetBool("MainMenu", true);
        //DeathScreenAnimator.SetBool("Is Dead", false);
    }
}
