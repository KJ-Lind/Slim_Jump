using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public Joystick joystick;

    public FloatingJoystick joystickState;

    //JoyStick joyStick;

    Vector3 joystick_dir;
    public Vector3 dir = Vector3.zero;

    public float Force = 10.0f; 

    public Rigidbody2D rigidBody;

    bool InAir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player = new Vector3(transform.position.x, transform.position.y);

        Vector2 dir = -joystick.Direction + player;

        if (joystickState.state == TouchState.k_Touching)
        {
            
            Debug.DrawLine(dir, transform.position, Color.magenta);
            Debug.Log("Jump Dir = " + dir);
            Debug.Log("Current State = " + joystickState.state);
        }
        
        if(joystickState.state == TouchState.k_TouchRelease)
        {
            rigidBody.AddForce(dir * Force, ForceMode2D.Impulse);
            Debug.Log("Jump Force Coinstant=" + Force);
            Debug.Log("Jump Dir = " + dir);
            if (!InAir)
            {
                InAir = true;
            }
            
            Debug.Log("Current State = " + joystickState.state);
            joystickState.state = TouchState.k_NoTouch;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            InAir = false;
        }

    }
}


