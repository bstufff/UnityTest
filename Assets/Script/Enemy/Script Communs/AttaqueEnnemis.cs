using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEnnemis : MonoBehaviour
{
    public float SpeedB = 0;
    public Variables Ennemis;
    public List<Variables> CroisésList = new List<Variables>();
    public List<Variables> Croisés = new List<Variables>();
    public string layerName = "Ally"; // Le nom du layer à filtrer

    private LayerMask layerMask; // Le LayerMask pour filtrer les colliders

    private void Start()
    {
        // Créer le LayerMask à partir du nom du layer
        layerMask = (LayerMask)LayerMask.GetMask(layerName);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((((int)1 << other.gameObject.layer) & layerMask) != 0)
        {
            Ennemis = GetComponent<Variables>();
            CroisésList.Add(other.GetComponent<Variables>());
            if (CroisésList[0].Encombat == false)
            {
                Croisés.Add(other.GetComponent<Variables>());

            }
            if (Croisés[0].Encombat == false)
            {
                Ennemis.Encombat = true;
                SpeedB = Ennemis.Speed;
                Ennemis.Speed = 0;
            }
            Croisés[0].Encombat = true;
            Croisés[0].Pv -= Ennemis.DegatsMob;
            if (Croisés.Count == 2 && Croisés[1].Encombat == false)
            {
                Croisés[1].Ensupport = true;

            }
            if (Croisés.Count == 3 && Croisés[1].Encombat == false && Croisés[2].Encombat == false)
            {
                Croisés[1].Ensupport = true;//OPTIONNEL
                Croisés[2].Ensupport = true;
            }

        }
        

    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if ((((int)1 << collision.gameObject.layer) & layerMask) != 0)
        {
            if (Croisés.Count != -1)
            {
                Croisés.RemoveAt(0);
                if (Croisés.Count == 0 && Ennemis.Encombat == true)
                {
                    Ennemis.Encombat = false;
                }
                Ennemis.Speed = SpeedB;

            }

        }



       
    }










}
