using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenAnimation : MonoBehaviour
{
    public Animator DeathScreenAnimator;

    private float timer = 0f;
    private bool Switch = false;
    private bool deadSwitch = false;
    private bool timerSwitch = false;

    public GameObject DeathScreenBackGround;

    void Update()
    {
        if (deadSwitch == true) DeathManager();
        timer += Time.deltaTime;
        if (timer >= 4 && timerSwitch == true)
        {
            SceneManager.LoadScene("MainMenu");
            Switch = false;
        }
    }

    private void DeathManager()
    {
        if (mainCharacter.totalCurrentHealth <= 0)
        {
            Switch = true;
            if (Switch == true)
            {
                timer = 0f;
                Switch = false;
            }
            DeathScreenAnimator.SetBool("Is Dead", true);
            DeathScreenBackGround.SetActive(true);
            deadSwitch = false;
            timerSwitch = true;
        }
        else
        {
            DeathScreenAnimator.SetBool("Is Dead", false);
            deadSwitch = false;
        }
    }
}
