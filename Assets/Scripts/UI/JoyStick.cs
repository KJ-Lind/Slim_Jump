using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    Vector3 originPos = Vector3.zero;
    public SpriteRenderer sprite;
    public Vector3 dirVec = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount > 0)
        {
            sprite.enabled = true;
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0.0f;
            float distance = Vector3.Distance(touchPos, originPos);
            if (distance < 1.5f)
            {
                transform.position = touchPos;
                dirVec = touchPos - originPos;
            }
            if(touch.phase == TouchPhase.Began)
            {
                originPos = transform.position;
            }
            
            Debug.DrawLine(originPos, transform.position, Color.red);
        }
        else
        {
            dirVec = Vector3.zero;
            sprite.enabled = false;
        }

    }
}
