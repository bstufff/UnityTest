using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody2D rb;//Rigidbody de l'ennemi : pour l'assigner il faut dragndrop sous unity le rigidbody de l'ennemi dans le champ corre

    public float moveSpeed;//Valeur par défaut de la vitesse

    public Transform target;//Point we want to move to
    public int pathIndex = 0;//Index du chemin 
    public float DistanceLeft;
    public float DistanceLeftOfOtherCheckPoints;
    [SerializeField] private List<float> PathLengths;
    public List<EnemySpawner.Path> pathArray;
    public EnemySpawner.Path pathTaken;
   
    public void SetPath (List<EnemySpawner.Path> path, int pathNumber){
        pathArray = path;
        pathTaken = pathArray[pathNumber];
    }
    public void Start()
    {
        Variables speedReference = GetComponent<Variables>();
        moveSpeed = speedReference.Speed;
        target = pathTaken.PathContents[pathIndex];//Here equals 0 (First point)
        PathLengths = new List<float> { Vector2.Distance(pathTaken.startPoint.position, pathTaken.PathContents[0].position) };
        for (int i = 0; i < pathTaken.PathContents.Length - 1; i++)
        {
            PathLengths.Add(Vector2.Distance(pathTaken.PathContents[i].position, pathTaken.PathContents[i + 1].position));
        }
        DistanceLeft = PathLengths.Sum();
        DistanceLeftOfOtherCheckPoints = DistanceLeft - PathLengths[0];

    }
    public void Update()
    {
        Variables speedReference = GetComponent<Variables>();
        moveSpeed = speedReference.Speed;
        DistanceLeft = Vector2.Distance(transform.position, pathTaken.PathContents[pathIndex].position) + DistanceLeftOfOtherCheckPoints;
        if (Vector2.Distance(target.position, transform.position) <= 1f)
        {//Si la distance entre l'ennemi et le point est de moins de 0.1, il passe au point suivant
            if (pathIndex != pathTaken.PathContents.Length-1) {
                DistanceLeftOfOtherCheckPoints -= Vector2.Distance(pathTaken.PathContents[pathIndex].position, pathTaken.PathContents[pathIndex + 1].position);
            }
            pathIndex++;//Passe au prochain point
            if (pathIndex == pathTaken.PathContents.Length)
            {//Si l'index des points du chemin est la même que la longueur de la liste "path", détruire l'ennemi
                Destroy(gameObject);//no shit
                //foutre le code pour enlever les vies
                return;
            }
            else
            {
                target = pathTaken.PathContents[pathIndex];//Assigne la position du point au prochain élément dans la liste

            }
                
        }

    }
    public void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;//Regarde le point

        rb.velocity = direction * moveSpeed;//Se déplace vers le point
    }
}
