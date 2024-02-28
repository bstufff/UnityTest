using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterBackUpDesespoir2 : MonoBehaviour
{
    public string layerName = "Ally"; // Le nom du layer à filtrer

    private LayerMask layerMask; // Le LayerMask pour filtrer les colliders
    AttaqueEnnemis EnnemyAttack;
    private void Start()
    {
        // Créer le LayerMask à partir du nom du layer
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
                EnnemyAttack.CroisésList.Add(otherVariables);
            }

            if (EnnemyAttack.CroisésList.Count > 0 && EnnemyAttack.CroisésList[0].Encombat == false)// null reff exp && le premier croisé est pas en combat
            {
                EnnemyAttack.Croisés.Add(otherVariables);
            }

            if (EnnemyAttack.CroisésList.Count > 0 && EnnemyAttack.CroisésList[0].Encombat == false)// null reff exp && le premier croisé est pas en combat
            {
                EnnemyAttack.Ennemis.Encombat = true;
                EnnemyAttack.Ennemis.Speed = 0;
            }

            if (EnnemyAttack.CroisésList.Count > 0)
            {
                EnnemyAttack.CroisésList[0].Encombat = true;
                EnnemyAttack.CroisésList[0].Ensupport = false;

                if (EnnemyAttack.CroisésList.Count >= 2 && EnnemyAttack.CroisésList[1].Encombat == false)
                {
                    EnnemyAttack.CroisésList[1].Ensupport = true;
                }

                if (EnnemyAttack.CroisésList.Count >= 3 && EnnemyAttack.CroisésList[1].Encombat == false && EnnemyAttack.CroisésList[2].Encombat == false)
                {
                    EnnemyAttack.CroisésList[1].Ensupport = true;
                    EnnemyAttack.CroisésList[2].Ensupport = true;
                }
            }
            HashSet<Variables> merge = new HashSet<Variables>();

            foreach (Variables v in EnnemyAttack.CroisésList)
            {
                merge.Add(v);
            }
            foreach (Variables v in EnnemyAttack.CroisésList)
            {
                merge.Add(v);
            }
            foreach (Variables v in EnnemyAttack.CroisésList)
            {
                merge.Add(v);
            }
            EnnemyAttack.CroisésList = new List<Variables>(merge);
        }
    }
}
