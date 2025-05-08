using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Pos : MonoBehaviour
{

    public GameObject[] nodes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < nodes.Length; i++)
        {

          nodes node = nodes[i].GetComponent<nodes>();
          if (node.IsActive)
          {
            Debug.Log("There Is Collision in node" + nodes[i].name);
            gameObject.transform.position = new Vector3(0.0f, nodes[i].transform.position.y, -1.0f);
          }
        }
    }


}
