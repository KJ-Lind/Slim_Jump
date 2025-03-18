using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    JoyStick joyStick;

    Vector3 joystick_dir;
    public Vector3 dir = Vector3.zero;

    public float Force = 10.0f; 

    public Rigidbody2D rigidBody;

    bool InAir;

    // Start is called before the first frame update
    void Start()
    {
        joyStick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStick>();
    }

    // Update is called once per frame
    void Update()
    { 
        joystick_dir = joyStick.dirVec;
        dir = joystick_dir + transform.position;
        Debug.DrawLine(dir, transform.position, Color.magenta);

        Vector2 JumpDir = new Vector2(joystick_dir.x, joystick_dir.y);
        float JumpForce = Force * joyStick.ImpForce;

        if (joyStick.InputActivated && joyStick.touch.phase == TouchPhase.Ended)
        {
            Debug.Log("Jump Force Coinstant=" + Force);
            Debug.Log("Jump Force Variable =" + joyStick.ImpForce);
            Debug.Log("Jump Force Total=" + JumpForce);

            Debug.Log("Jump Dir = " + JumpDir.normalized);
            if (!InAir)
            {
                rigidBody.AddForce(JumpDir.normalized * JumpForce, ForceMode2D.Impulse);
                InAir = true;
            }
        }

        Debug.Log(InAir);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            InAir = false;
        }

    }
}


