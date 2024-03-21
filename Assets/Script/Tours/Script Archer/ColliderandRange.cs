using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ColliderandRange : MonoBehaviour
{

    public Transform enemy;
    public Vector3 targetposition;
    public float rateOfFire = 3f;
    public int dmg = 20;
    [SerializeField]private List<GameObject> EnemiesInRange;
    private Stopwatch shootDelay = Stopwatch.StartNew();



    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemiesInRange.Add(collision.gameObject);
        GetPosition();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        EnemiesInRange.Remove(other.gameObject);
        if (EnemiesInRange.Count != 0) { 
            GetPosition();
        }
    }
    private void FixedUpdate()
    {
        GameObject target = GetPosition();
        if (shootDelay.ElapsedMilliseconds >= 3000 && EnemiesInRange.Count !=0)
        {
            target.gameObject.GetComponent<Variables>().Pv -= 20;
            shootDelay.Restart();
        }
    }
    public GameObject GetPosition() 
    {
        if (EnemiesInRange.Count != 0)
        {
            GameObject First=null;
            float FirstsDistance=-1;
            foreach (GameObject enemy in EnemiesInRange)
            {
                if (FirstsDistance == -1) {
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
                return First;
            }
        }
        return null;
    }






}
