using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    Transform tr_;
    SpriteRenderer spriteRenderer_;
    Vector2 velocity;
    float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr_ = GetComponent<Transform>();
        spriteRenderer_ = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 pos = tr_.position;

        pos.x += velocity.x * speed * Time.fixedDeltaTime;

        tr_.position = pos;
    }


    // Update is called once per frame
    void Update()
    {
        

    }

    public void MoveRight()
    {
        spriteRenderer_.flipX = false;
        velocity = Vector2.right;
    }

    public void MoveLeft()
    {
        spriteRenderer_.flipX = true;
        velocity = Vector2.left;
    }

    public void MoveStop()
    {
        velocity = Vector2.zero;
    }

}
