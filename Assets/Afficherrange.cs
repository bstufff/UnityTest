using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afficherrange : MonoBehaviour
{
    public SpriteRenderer Rangeunit;

    public void OnMouseDown()
    {
      if (Input.GetMouseButtonDown(1))
      {
            Debug.Log("oui");
            Rangeunit.enabled = true;

      }

        
    }




}
