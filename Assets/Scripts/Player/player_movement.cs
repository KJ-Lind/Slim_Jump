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

    public Vector2 groundedPos;

    private Vector2 originalScale; 
    private Vector2 newScale;
    private float initialScale = 1.0f;
    private bool WasGrounded = true;


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

      groundedPos = transform.position;
      originalScale = transform.localScale;

      rigidBody.drag = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {

        bool currentlyGrounded = IsGrounded(); 

        if(!WasGrounded && currentlyGrounded) 
        {
          StartCoroutine(SquishAnimation());
        }

        WasGrounded = currentlyGrounded;

        if (IsGrounded())
        {
          rigidBody.drag = 5.0f;
        }
        else
        {
          rigidBody.drag = 0.0f;
        }


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

            transform.localScale = new Vector2(originalScale.x * 1.2f, originalScale.y * 0.9f);

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
            transform.localScale = originalScale;

            if (IsGrounded())
            {
                rigidBody.AddForce(lastDir * Force, ForceMode2D.Impulse);
            }
            
            lastDir = Vector2.zero;
            joystickState.state = TouchState.k_NoTouch;
        }
        
    }

    IEnumerator SquishAnimation()
    {
      float squishDuration = 0.15f;
      float t = 0;

      Vector2 squishScale = new Vector2(originalScale.x * 1.2f, originalScale.y * 0.8f);

      // Squish
      while (t < squishDuration)
      {
        transform.localScale = Vector2.Lerp(originalScale, squishScale, t / squishDuration);
        t += Time.deltaTime;
        yield return null;
      }

      // Reset
      t = 0;
      while (t < squishDuration)
      {
        transform.localScale = Vector2.Lerp(squishScale, originalScale, t / squishDuration);
        t += Time.deltaTime;
        yield return null;
      }

      transform.localScale = originalScale;
    }

  public bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position, GroundBoxSize, 0, -transform.up, GroundCastDist, GroundMask))
        {
            groundedPos = transform.position;
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


