using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    
    Variables Croisés;
    public List<Variables> EnnemisList = new List<Variables>();
    public Variables Ennemis;
    public int IndexList;
    private bool Enattente = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        EnnemisList.Add(other.GetComponent<Variables>());
        IndexList = EnnemisList.IndexOf(other.GetComponent<Variables>());   
        Croisés = GetComponent<Variables>();
        Ennemis = EnnemisList[0];
        if(Croisés.Ensupport == true)
        {
            Ennemis = EnnemisList[IndexList];

        }
        Ennemis.Pv -= Croisés.DegatsMob;
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(!Enattente)
        {
            StartCoroutine(Attack());
        }          
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        IndexList = EnnemisList.IndexOf(collision.GetComponent<Variables>());
        EnnemisList.RemoveAt(IndexList);
        if(EnnemisList.Count != 0)
        {
            Croisés.Encombat = false;
            Croisés.Ensupport = true;
            Ennemis = EnnemisList[0];
        } 
        if(EnnemisList.Count == 0)
        {
            Croisés.Encombat = false;
            Croisés.Ensupport = false;
        }
        
    }

    IEnumerator Attack()
    {
        Enattente = true;
        yield return new WaitForSeconds(2f);

        Ennemis.Pv -= Croisés.DegatsMob;

        Enattente = false;

    }





}
