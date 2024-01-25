using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableChateauEtGameOver : MonoBehaviour
{
    public int Pv = 30;

    public void Update()
    {
        if(Pv <= 0) 
        {
            Debug.Log("GAMEOVER");// rediriger vers scène GameOver
        }
    }
}
