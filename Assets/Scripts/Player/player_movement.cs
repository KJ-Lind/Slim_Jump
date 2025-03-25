using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public Joystick joystick;

    public FloatingJoystick joystickState;

    //JoyStick joyStick;

    Vector3 joystick_dir;

    Vector2 lastDir;

    //[SerializeField] private Animator animator;
   

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

        if (joystickState.state == TouchState.k_Touching)
        {
            lastDir = -joystick.Direction;
            Debug.DrawLine(lastDir, transform.position, Color.magenta);

        }
        
        if(joystickState.state == TouchState.k_TouchRelease)
        {
            //dir = transform.TransformDirection(dir);

            if (!InAir)
            {
                rigidBody.AddForce(lastDir * Force, ForceMode2D.Impulse);
               // animator.SetBool("IsJumping", true);
                InAir = true;
            }
            else
            {
                //animator.SetBool("IsJumping", false);
            }
            
            lastDir = Vector2.zero;
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


