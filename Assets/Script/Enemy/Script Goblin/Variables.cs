using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int Pv = 10;
    public int DegatsMob = 10;
    public int DegatsChateau = 10;
    public float Speed = 50f;
    public int ValeurGold = 10;

    public void Start()
    {
        EnemyMovement speedReference = GetComponent<EnemyMovement>();
        speedReference.moveSpeed = Speed;
    }
}
