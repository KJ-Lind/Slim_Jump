using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Pos : MonoBehaviour
{
    public Transform player;
    Transform camerapos;
    public float Y_Screen_Snap = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        camerapos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y >= camerapos.position.y + (Y_Screen_Snap / 2f))
        {
            transform.position = new Vector3(camerapos.position.x, camerapos.position.y + Y_Screen_Snap, -10.0f);
        }

        if (player.position.y <= camerapos.position.y - (Y_Screen_Snap / 2f))
        {
            transform.position = new Vector3(camerapos.position.x, camerapos.position.y - Y_Screen_Snap, - 10.0f);
        }
    }
}
