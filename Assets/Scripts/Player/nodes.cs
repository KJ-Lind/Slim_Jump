using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodes : MonoBehaviour
{
  public bool IsActive = false;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      IsActive = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      IsActive = false;
    }
  }
}
