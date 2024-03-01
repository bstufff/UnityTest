using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PertePv : MonoBehaviour
{
    public VariableChateauEtGameOver pv;
    public void Start() 
    { 
        pv = GetComponent<VariableChateauEtGameOver>();
    }
    public void EnemyArrival(Transform enemy) {
        Variables target = enemy.GetComponent<Variables>();
        pv.Pv -= target.DegatsChateau;
        Debug.Log("Le château a pris " + target.DegatsChateau + " dégats, il reste " + pv.Pv + " pv au château");
    }
    //public void OnTriggerEnter2D(Collider2D col)
    //{
    //    Debug.Log("enemy passed");
    //    if (col.name != "mettre le nom du hero" || col.name != "mettre le nom des projectiles")
    //    {
            
    //        
    //        DegatsSubits = Target.DegatsChateau;
    //        Debug.Log(DegatsSubits);
    //        pv.Pv = pv.Pv - DegatsSubits;
    //        Debug.Log(pv.Pv);
    //    }
    //}
}
