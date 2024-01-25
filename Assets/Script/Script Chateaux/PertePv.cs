using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PertePv : MonoBehaviour
{
    private int DegatsSubits;
    public VariableChateauEtGameOver pv;
    public void Start() 
    { 
        pv = GetComponent<VariableChateauEtGameOver>();
    }   
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name != "mettre le nom du hero" || col.name != "mettre le nom des projectiles")
        {
            Debug.Log("enemy passed");
            Variables Target = col.GetComponent<Variables>();
            DegatsSubits = Target.DegatsChateau;
            Debug.Log(DegatsSubits);
            pv.Pv = pv.Pv - DegatsSubits;
            Debug.Log(pv.Pv);
        }
    }
}
