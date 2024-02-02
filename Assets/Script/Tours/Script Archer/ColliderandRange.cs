using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ColliderandRange : MonoBehaviour
{

    public Transform enemy;
    public Vector3 targetposition;
    [SerializeField]private List<GameObject> EnemiesInRange;
    private List<string> enemyNames;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemiesInRange.Add(collision.gameObject);
        GetPosition();
        int gold = collision.GetComponent<Variables>().ValeurGold;
        collision.GetComponent<Variables>().ValeurGold = gold-5;

        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        EnemiesInRange.Remove(other.gameObject);
        if (EnemiesInRange.Count != 0) { 
            GetPosition();
        }
        Debug.Log(other.GetComponent<Variables>().ValeurGold);
    }
    private void FixedUpdate()
    {
        GetPosition();
        
    }

    public void GetPosition() 
    {
        if (EnemiesInRange.Count != 0)
        {
            GameObject First=null;
            float FirstsDistance=-1;
            foreach (GameObject enemy in EnemiesInRange)
            {
                if (First == null) {
                    First = enemy;
                    FirstsDistance = First.GetComponent<EnemyMovement>().DistanceLeft;
                }
                else if (enemy.GetComponent<EnemyMovement>().DistanceLeft <= FirstsDistance)
                {
                    First = enemy;
                    FirstsDistance = First.GetComponent<EnemyMovement>().DistanceLeft;
                }
            }
            if (First!=null) {
                Vector3 dir = First.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            
        }
            
    }





}
