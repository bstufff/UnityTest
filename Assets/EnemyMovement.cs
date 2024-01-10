using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;//Point we want to move to
    private int pathIndex = 0;//Index du chemin 

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];//Here equals 0 (First point)
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) {
            pathIndex++;//Passe au prochain point
           
            if (pathIndex == LevelManager.main.path.Length) { 
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
