using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Pos : MonoBehaviour
{

    public GameObject[] nodes;

    public player_movement slime;

    // Start is called before the first frame update
    void Start()
    {
      slime = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < nodes.Length; i++)
        {

          nodes node = nodes[i].GetComponent<nodes>();
          if (node.IsActive && slime.IsGrounded())
          {
            //Debug.Log("There Is Collision in node" + nodes[i].name);
            gameObject.transform.position = new Vector3(0.0f, nodes[i].transform.position.y, -1.0f);
          }

          if(node.IsActive && slime.transform.position.y < slime.groundedPos.y)
          {
            //Debug.Log("There Is Collision in node" + nodes[i].name);
            gameObject.transform.position = new Vector3(0.0f, nodes[i].transform.position.y, -1.0f);
          }

        }
    }


}
