using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Barr : MonoBehaviour
{
  public Slider progress;

  public Transform slime;
  public Transform end;

  Vector2 distance;
  float MaxDist;

  // Start is called before the first frame update
  void Start()
    {
      distance = end.position - slime.position;
      MaxDist = distance.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
      distance = end.position - slime.position;

      progress.value = distance.y / MaxDist;

    }
}
