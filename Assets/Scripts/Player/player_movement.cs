using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public FloatingJoystick joyStick;

    Vector3 joystick_dir;
    public Vector3 dir = Vector3.zero;

    public float Force = 10.0f; 

    public Rigidbody2D rigidBody;

    bool InAir;

    Touch touch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        joystick_dir = joyStick.Direction;
        dir = -1 * joystick_dir + transform.position;
        Debug.DrawLine(dir, transform.position, Color.magenta);

        Vector2 JumpDir = new Vector2(dir.x, dir.y);
        float JumpForce = Force * dir.magnitude;
        
        rigidBody.AddForce( JumpDir * JumpForce, ForceMode2D.Impulse);
        //if ()
        //{
        //    Debug.Log("Jump Force Coinstant=" + Force);
        //    Debug.Log("Jump Force Variable =" + dir.magnitude);
        //    Debug.Log("Jump Force Total=" + JumpForce);

        //    Debug.Log("Jump Dir = " + JumpDir.normalized);
        //    if (!InAir)
        //    {
        //        InAir = true;
        //    }
        //}

        //Debug.Log(InAir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            InAir = false;
        }

    }
}


