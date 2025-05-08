using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public Joystick joystick;

    public FloatingJoystick joystickState;

    public GameObject dir_indicator;

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
      dir_indicator.GetComponentInChildren<Renderer>().enabled = false;
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
            dir_indicator.GetComponentInChildren<Renderer>().enabled = true;

            lastDir = -joystick.Direction;
            
            Vector2 player_pos = transform.position;
            var dir_ind = -joystick.Direction;
            dir_indicator.transform.localScale = new Vector2(dir_ind.magnitude * 1.0f, dir_ind.magnitude * 2f);
            var angle = Mathf.Atan2(dir_ind.x, dir_ind.y) * Mathf.Rad2Deg;
            dir_indicator.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            Debug.DrawLine(lastDir, transform.position, Color.magenta);

        }
        
        if(joystickState.state == TouchState.k_TouchRelease)
        {
            //dir = transform.TransformDirection(dir);
            dir_indicator.GetComponentInChildren<Renderer>().enabled = false;

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


