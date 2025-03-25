using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu_Manager : MonoBehaviour
{
    public void OnPauseMenu(bool IsPaused)
    {
        if (IsPaused) Time.timeScale = 0f;
        else if (!IsPaused) Time.timeScale = 1f;
    }

    public void OnGameExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }


    public void OnRetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Level");
    }
}
