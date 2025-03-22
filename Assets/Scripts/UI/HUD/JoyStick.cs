using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public Vector3 originPos = Vector3.zero;
    public Vector3 dirVec = Vector3.zero;

    public SpriteRenderer Joystick;
    public SpriteRenderer Area;

    public Transform StickPos;
    public bool InputActivated;
    public Touch touch;
    public float ImpForce;

    // Start is called before the first frame update
    void Start()
    {
        InputActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount > 0)
        {
            Joystick.enabled = true;
            Area.enabled = true;
            touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0.0f;
            if (touch.phase == TouchPhase.Began)
            {
                originPos = touchPos;
            }

            transform.position = originPos;

            float distance = Vector3.Distance(touchPos, originPos);
            
            if (distance < 1.5f)
            {
                StickPos.position = touchPos;
                dirVec = (originPos - StickPos.position);
                ImpForce = distance;
            }
            
            
            Debug.DrawLine(originPos, StickPos.position, Color.red);

            InputActivated = true; 
        }
        else
        {
            dirVec = Vector3.zero;
            Joystick.enabled = false;
            Area.enabled = false;
            InputActivated = false;
        }

    }
}
