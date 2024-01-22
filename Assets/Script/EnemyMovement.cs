using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;//Rigidbody de l'ennemi : pour l'assigner il faut dragndrop sous unity le rigidbody de l'ennemi dans le champ corre

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;//Valeur par défaut de la vitesse

    private Transform target;//Point we want to move to
    private int pathIndex = 0;//Index du chemin 

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];//Here equals 0 (First point)
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) {//Si la distance entre l'ennemi et le point est de moins de 0.1, il passe au point suivant
            pathIndex++;//Passe au prochain point
           
            if (pathIndex == LevelManager.main.path.Length) { //Si l'index des points du chemin est la même que la longueur de la liste "path", détruire l'ennemi
                Destroy(gameObject);//no shit
                //foutre le code pour enlever les vies
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];//Assigne la position du point au prochain élément dans la liste
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;//Regarde le point

        rb.velocity = direction * moveSpeed;//Se déplace vers le point
    }
}
