using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEnnemis : MonoBehaviour
{
    public float SpeedB = 0;
    public Variables Ennemis;
    public List<Variables> Crois�sList = new List<Variables>();
    public List<Variables> Crois�s = new List<Variables>();
    public string layerName = "Ally"; // Le nom du layer � filtrer

    private LayerMask layerMask; // Le LayerMask pour filtrer les colliders

    private void Start()
    {
        // Cr�er le LayerMask � partir du nom du layer
        layerMask = (LayerMask)LayerMask.GetMask(layerName);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((((int)1 << other.gameObject.layer) & layerMask) != 0)
        {
            Ennemis = GetComponent<Variables>();
            Crois�sList.Add(other.GetComponent<Variables>());
            if (Crois�sList[0].Encombat == false)
            {
                Crois�s.Add(other.GetComponent<Variables>());

            }
            if (Crois�s[0].Encombat == false)
            {
                Ennemis.Encombat = true;
                SpeedB = Ennemis.Speed;
                Ennemis.Speed = 0;
            }
            Crois�s[0].Encombat = true;
            Crois�s[0].Pv -= Ennemis.DegatsMob;
            if (Crois�s.Count == 2 && Crois�s[1].Encombat == false)
            {
                Crois�s[1].Ensupport = true;

            }
            if (Crois�s.Count == 3 && Crois�s[1].Encombat == false && Crois�s[2].Encombat == false)
            {
                Crois�s[1].Ensupport = true;//OPTIONNEL
                Crois�s[2].Ensupport = true;
            }

        }
        

    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if ((((int)1 << collision.gameObject.layer) & layerMask) != 0)
        {
            if (Crois�s.Count != -1)
            {
                Crois�s.RemoveAt(0);
                if (Crois�s.Count == 0 && Ennemis.Encombat == true)
                {
                    Ennemis.Encombat = false;
                }
                Ennemis.Speed = SpeedB;

            }

        }



       
    }










}
