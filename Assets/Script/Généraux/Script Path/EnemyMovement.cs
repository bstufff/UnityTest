using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;//Rigidbody de l'ennemi : pour l'assigner il faut dragndrop sous unity le rigidbody de l'ennemi dans le champ corre

    [Header("Attributes")]
    [SerializeField] public float moveSpeed;//Valeur par d�faut de la vitesse

    private Transform target;//Point we want to move to
    private int pathIndex = 0;//Index du chemin 
    public float DistanceLeft;
    private float DistanceLeftOfOtherCheckPoints;
    [SerializeField] private List<float> PathLengths;
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];//Here equals 0 (First point)
        PathLengths = new List<float> { Vector2.Distance(LevelManager.main.startPoint.position, LevelManager.main.path[0].position) };
        for (int i = 0; i < LevelManager.main.path.Length - 1; i++)
        {
            PathLengths.Add(Vector2.Distance(LevelManager.main.path[i].position, LevelManager.main.path[i + 1].position));
        }
        DistanceLeft = PathLengths.Sum();
        DistanceLeftOfOtherCheckPoints = DistanceLeft - PathLengths[0];

    }
    private void Update()
    {
        DistanceLeft = Vector2.Distance(transform.position, LevelManager.main.path[pathIndex].position) + DistanceLeftOfOtherCheckPoints;
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {//Si la distance entre l'ennemi et le point est de moins de 0.1, il passe au point suivant
            if (pathIndex != LevelManager.main.path.Length-1) {
                DistanceLeftOfOtherCheckPoints -= Vector2.Distance(LevelManager.main.path[pathIndex].position, LevelManager.main.path[pathIndex + 1].position);
            }
            pathIndex++;//Passe au prochain point
            if (pathIndex == LevelManager.main.path.Length)
            {//Si l'index des points du chemin est la m�me que la longueur de la liste "path", d�truire l'ennemi
                Destroy(gameObject);//no shit
                //foutre le code pour enlever les vies
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];//Assigne la position du point au prochain �l�ment dans la liste

                }
                
        }

    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;//Regarde le point

        rb.velocity = direction * moveSpeed;//Se d�place vers le point
    }
}
