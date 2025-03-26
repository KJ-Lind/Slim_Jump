using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Anim : MonoBehaviour
{
    public Dialog_Manager dialog;

    public GameObject mainCanvas;

    public GameObject finger;

    public float tutorialDuration = 10.0f;

    private float localTime;

    private bool tutorialActive = false;

    private void Update()
    {


        if (dialog.DialogDone && !tutorialActive)
        {
            localTime = tutorialDuration;
            finger.SetActive(true);
        }

        if(localTime <= 0 && tutorialActive)
        {
            mainCanvas.SetActive(false);
        }

        localTime -= Time.deltaTime;

    }



}
