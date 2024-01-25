using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mort : MonoBehaviour
{
    //public VariablesGold MontantGold;
    public Variables enemy;
    public void Start()
    {
        enemy = GetComponent<Variables>();
    }

    private void Update()
    {
        //MontantGold = GetComponent<VariablesGold>();
        if (enemy != null && enemy.Pv <= 0)
        {
            Debug.Log("mort");
            //Gold += enemy.ValeurGold;
            //
            GameObject.Destroy(gameObject);
        }
    }
}
