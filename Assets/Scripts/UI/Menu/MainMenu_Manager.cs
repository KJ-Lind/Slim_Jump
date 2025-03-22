using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

enum SelectedMenu
{
    k_Start = 0,
    k_Options
}

public class MainMenu_Manager : MonoBehaviour
{
    private int m_SelectedIndex;
    SelectedMenu m_SelectedMenu;

    public Canvas[] Menus;

    public void OnStartGame()
    {
        SceneManager.LoadScene("Main_Level");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }


}
