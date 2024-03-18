using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreenAnimation : MonoBehaviour
{
    public Animator DeathScreenAnimator;

    private float timer = 0f;
    private bool Switch = false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4 && Switch == true)
        {
            SceneManager.LoadScene("MainMenu");
            Switch = false;
        }
    }

    public void LoadLastSave()
    {
        Switch = true;
        timer = 0f;
        DeathScreenAnimator.SetBool("LastSave", true);
    }

    public void MainMenu()
    {
        Switch = true;
        timer = 0f;
        DeathScreenAnimator.SetBool("MainMenu", true);
    }
}
