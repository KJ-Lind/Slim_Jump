using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_End : MonoBehaviour
{
    public GameObject EndScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Do end animations

        Time.timeScale = 0f;
        EndScreen.SetActive(true);
    }
}
