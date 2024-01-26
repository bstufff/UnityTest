using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderandRange : MonoBehaviour
{

    public Transform enemy;
    public Vector3 targetposition;
    public void OnTriggerStay2D(Collider2D range)
    {
        if(range.name != "Hero")
        {

            enemy = range.GetComponent<Transform>();
            targetposition = enemy.position;
            Debug.Log("OUI");

        }
  
    }

    public Vector3 GetPosition(Vector3 Target) 
    {
       



        return Target;
    }






}
