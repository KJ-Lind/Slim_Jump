using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    [SerializeField] Text scoreTxt;
  [SerializeField] Player_Stats stats;
  private void Start()
  {
    stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats>();
  }

  // Update is called once per frame
  void Update()
    {
      int score = (int) stats.Score();
      scoreTxt.text = score.ToString();
    }
}
