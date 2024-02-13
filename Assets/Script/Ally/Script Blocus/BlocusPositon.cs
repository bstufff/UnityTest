using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocusPositon : MonoBehaviour
{
    public Transform CurrentTarget;
    public Vector3 direction;


    public void Update()
    {
        if (CurrentTarget != null) 
        { 
            direction = CurrentTarget.position - transform.position;

            direction.Normalize();      

        }
        
    }
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        CurrentTarget = other.transform;
        
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform == CurrentTarget)
        {

            CurrentTarget = null;

            Collider2D[] Colliders =  GetComponents<Collider2D>();
         
            foreach (Collider2D collider in Colliders)
            {
                List<Collider2D> overlapcolliders = new List<Collider2D>();
                collider.OverlapCollider(new ContactFilter2D(), overlapcolliders);
                
                foreach(Collider2D overlapcoll in overlapcolliders)
                {
                    if(overlapcoll != null && overlapcoll.transform != null)
                    {
                        CurrentTarget = overlapcoll.transform;
                        return;
                    }
                }

            }






        }

        
    }








}
