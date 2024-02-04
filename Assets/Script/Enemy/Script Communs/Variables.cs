using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Variables g�n�rales
    public int Pv = 10;
    public int PvMax = 10;
    public int DegatsMob = 10;
    public int DegatsChateau = 10;
    public float Speed = 3f;
    public int ValeurGold = 15;
    public bool Encombat = false;
    public bool Ensupport = false;
    public void CorrectionHeal() 
    {
        if (Pv > PvMax) 
        { 
            Pv = PvMax;
        }
    }
}
