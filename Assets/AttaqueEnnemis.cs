using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEnnemis : MonoBehaviour
{
    Variables Ennemis;
    public List<Variables> CroisésList = new List<Variables>();
    public List<Variables> Croisés = new List<Variables>();
    private bool Enattente = false;

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
            Ennemis.Speed = 0;
        }
        Croisés[0].Encombat = true;
        Croisés[0].Pv -= Ennemis.DegatsMob;
        if (Croisés.Count == 2) 
        { 
            Croisés[1].Ensupport = true;

        }
        if(Croisés.Count == 3)
        {
            Croisés[1].Ensupport = true;//OPTIONNEL
            Croisés[2].Ensupport = true;
        }
       

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
     
        if (!Enattente)
        {
            StartCoroutine(Attack());
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Croisés.RemoveAt(0);


    }

    IEnumerator Attack()
    {
        Enattente = true;
        yield return new WaitForSeconds(2f);

        Croisés[0].Pv -= Ennemis.DegatsMob;

        Enattente = false;

    }










}
