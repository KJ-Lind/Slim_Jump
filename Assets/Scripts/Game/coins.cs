using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
  [SerializeField]float score_ = 5.0f;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("COLISION");
    if(collision.tag == "Player")
    {
      Player_Stats stats = collision.GetComponent<Player_Stats>();
      stats.SetScore(score_);
      Destroy(gameObject);
    }
  }

}
