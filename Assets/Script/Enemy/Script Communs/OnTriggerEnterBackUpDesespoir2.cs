using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterBackUpDesespoir2 : MonoBehaviour
{
    public string layerName = "Ally"; // Le nom du layer � filtrer

    private LayerMask layerMask; // Le LayerMask pour filtrer les colliders
    AttaqueEnnemis EnnemyAttack;
    private void Start()
    {
        // Cr�er le LayerMask � partir du nom du layer
        layerMask = (LayerMask)LayerMask.GetMask(layerName);
    }
    private void Update()
    {
        EnnemyAttack = gameObject.GetComponent<AttaqueEnnemis>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((((int)1 << other.gameObject.layer) & layerMask) != 0)
        {
            EnnemyAttack.Ennemis = GetComponent<Variables>();
            Variables otherVariables = other.GetComponent<Variables>();

            if (otherVariables.Encombat == false)
            {
                EnnemyAttack.Crois�sList.Add(otherVariables);
            }

            if (EnnemyAttack.Crois�sList.Count > 0 && EnnemyAttack.Crois�sList[0].Encombat == false)// null reff exp && le premier crois� est pas en combat
            {
                EnnemyAttack.Crois�s.Add(otherVariables);
            }

            if (EnnemyAttack.Crois�sList.Count > 0 && EnnemyAttack.Crois�sList[0].Encombat == false)// null reff exp && le premier crois� est pas en combat
            {
                EnnemyAttack.Ennemis.Encombat = true;
                EnnemyAttack.Ennemis.Speed = 0;
            }

            if (EnnemyAttack.Crois�sList.Count > 0)
            {
                EnnemyAttack.Crois�sList[0].Encombat = true;
                EnnemyAttack.Crois�sList[0].Ensupport = false;

                if (EnnemyAttack.Crois�sList.Count >= 2 && EnnemyAttack.Crois�sList[1].Encombat == false)
                {
                    EnnemyAttack.Crois�sList[1].Ensupport = true;
                }

                if (EnnemyAttack.Crois�sList.Count >= 3 && EnnemyAttack.Crois�sList[1].Encombat == false && EnnemyAttack.Crois�sList[2].Encombat == false)
                {
                    EnnemyAttack.Crois�sList[1].Ensupport = true;
                    EnnemyAttack.Crois�sList[2].Ensupport = true;
                }
            }
            HashSet<Variables> merge = new HashSet<Variables>();

            foreach (Variables v in EnnemyAttack.Crois�sList)
            {
                merge.Add(v);
            }
            foreach (Variables v in EnnemyAttack.Crois�sList)
            {
                merge.Add(v);
            }
            foreach (Variables v in EnnemyAttack.Crois�sList)
            {
                merge.Add(v);
            }
            EnnemyAttack.Crois�sList = new List<Variables>(merge);
        }
    }
}
