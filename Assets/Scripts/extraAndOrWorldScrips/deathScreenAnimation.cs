using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenAnimation : MonoBehaviour
{
    public Animator DeathScreenAnimator;

    private float timer = 0f;
    private float timer2 = 0f;
    private bool Switch = false;
    private bool Switch2 = false;
    private bool Switch3 = false;
    public GameObject DeathScreenBackGround;

    void Update()
    {
        DeathManager();
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer >= 4 && Switch == true)
        {
            SceneManager.LoadScene("MainMenu");
            Switch = false;
        }

        if (timer2 >= 1.5f && Switch2 == true)
        {
            Debug.Log("D");
            DeathScreenBackGround.SetActive(true);
            Switch2 = false;
            Switch3 = true;
        }
    }

    private void DeathManager()
    {

        if (mainCharacter.totalCurrentHealth <= 0 && !(DeathScreenAnimator.GetBool("MainMenu") == true || DeathScreenAnimator.GetBool("LastSave") == true))
        {
            DeathScreenAnimator.SetBool("Is Dead", true);
            if (Switch3 == true)
            {
                timer2 = 0;
            }
            Switch2 = true;
            Switch3 = false;
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
