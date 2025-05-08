using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Script : MonoBehaviour
{
    public float tutorial_Duration = 5.0f;

    public float currTimer;

    // Start is called before the first frame update
    void Start()
    {
        currTimer = tutorial_Duration;
    }

    // Update is called once per frame
    void Update()
    {
        currTimer -= Time.deltaTime;
        if(currTimer <= 0) 
        {

            gameObject.SetActive(false);            

        }
    }
}
