using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEnnemis : MonoBehaviour
{
    public float SpeedB = 0;
    public Variables Ennemis;
    public List<Variables> CroisésList = new List<Variables>();
    public List<Variables> Croisés = new List<Variables>();
    

    public void OnTriggerEnter2D(Collider2D other)
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
        if(Croisés.Count == 3 && Croisés[1].Encombat == false && Croisés[2].Encombat == false)
        {
            Croisés[1].Ensupport = true;//OPTIONNEL
            Croisés[2].Ensupport = true;
        }
       

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Croisés.RemoveAt(0);
        if(Croisés.Count == 0 && Ennemis.Encombat == true) 
        { 
            Ennemis.Encombat = false;
        }
        Ennemis.Speed = SpeedB;
    }










}
