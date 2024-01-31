using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Variables générales
    public int Pv = 10;
    public int DegatsMob = 10;
    public int DegatsChateau = 10;
    public float Speed = 3f;
    public int ValeurGold = 15;
    
}

public class IsVisibleBy : MonoBehaviour
{
    public bool Archer = false;
    public bool Mage = false;
    public bool Mortier = false;
    public bool Caserne = true;
    public bool SlowingTower = false;
}
