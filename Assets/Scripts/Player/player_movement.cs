using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    JoyStick joyStick;

    Vector3 joystick_dir;
    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        joyStick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStick>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        joystick_dir = joyStick.dirVec;
        dir = joystick_dir.normalized;
        Debug.DrawLine(dir, transform.position, Color.magenta);
    }
}
