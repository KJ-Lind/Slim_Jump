using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    [Header("Ground Box Cast")]

    [SerializeField] Vector2 GroundBoxSize;
    [SerializeField] float GroundCastDist;
    [SerializeField] LayerMask GroundMask;

    [Header("Wall Box Cast")]

    [SerializeField] Vector2 WallBoxSize;
    [SerializeField] float WallCastDist;
    [SerializeField] LayerMask WallMask;
    [SerializeField] float BounceForce;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (IsWall_Right() && !IsGrounded())
        {
            rigidBody.AddForce(Vector2.left * BounceForce, ForceMode2D.Impulse);
        }
        else if (IsWall_Left() && !IsGrounded())
        {
            rigidBody.AddForce(Vector2.right * BounceForce, ForceMode2D.Impulse);
        }

        Vector2 player = new Vector3(transform.position.x, transform.position.y);

        if (joystickState.state == TouchState.k_Touching)
        {
            lastDir = -joystick.Direction;
            Debug.DrawLine(lastDir, transform.position, Color.magenta);

        }
        
        if(joystickState.state == TouchState.k_TouchRelease)
        {
            //dir = transform.TransformDirection(dir);

            if (IsGrounded())
            {
                rigidBody.AddForce(lastDir * Force, ForceMode2D.Impulse);
            }
            
            lastDir = Vector2.zero;
            joystickState.state = TouchState.k_NoTouch;
        }
        
    }

    public bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position, GroundBoxSize, 0, -transform.up, GroundCastDist, GroundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsWall_Right()
    {
        if (Physics2D.BoxCast(transform.position, WallBoxSize, 0, transform.right, WallCastDist, WallMask))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool IsWall_Left()
    {
        if (Physics2D.BoxCast(transform.position, WallBoxSize, 0, -transform.right, WallCastDist, WallMask))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * GroundCastDist, GroundBoxSize);

        Gizmos.DrawWireCube(transform.position - transform.right * WallCastDist, WallBoxSize);

        Gizmos.DrawWireCube(transform.position + transform.right * WallCastDist, WallBoxSize);

    }

}


