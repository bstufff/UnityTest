using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocusPositon : MonoBehaviour
{
    public Transform CurrentTarget;
    public float speed = 200f; //get component
    public Vector3 mouvement;
     
    public void Update()
    {
        if (CurrentTarget != null) 
        { 
            Vector3 direction = CurrentTarget.position - transform.position;

            direction.Normalize();

            mouvement = direction*speed*Time.deltaTime;

             

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
