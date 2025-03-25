using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    float currentTime;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        timer.text = time.ToString(@"m\:ss");

    }

}
