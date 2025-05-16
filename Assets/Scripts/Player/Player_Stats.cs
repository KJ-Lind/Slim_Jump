using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
  float score = 0.0f;

  public void SetScore(float score_)
  {
    score += score_;
  }

  public float Score()
  {
    return score; 
  }

}
