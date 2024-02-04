using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    
    Variables Crois�s;
    public List<Variables> EnnemisList = new List<Variables>();
    public Variables Ennemis;
    public int IndexList;
    private bool Enattente = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        EnnemisList.Add(other.GetComponent<Variables>());
        IndexList = EnnemisList.IndexOf(other.GetComponent<Variables>());   
        Crois�s = GetComponent<Variables>();
        Ennemis = EnnemisList[0];
        if(Crois�s.Ensupport == true)
        {
            Ennemis = EnnemisList[IndexList];

        }
        Ennemis.Pv -= Crois�s.DegatsMob;
        
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
            Crois�s.Encombat = false;
            Crois�s.Ensupport = true;
            Ennemis = EnnemisList[0];
        } 
        if(EnnemisList.Count == 0)
        {
            Crois�s.Encombat = false;
            Crois�s.Ensupport = false;
        }
        
    }

    IEnumerator Attack()
    {
        Enattente = true;
        yield return new WaitForSeconds(2f);

        Ennemis.Pv -= Crois�s.DegatsMob;

        Enattente = false;

    }





}
