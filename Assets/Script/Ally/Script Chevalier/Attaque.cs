using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    
    public Variables Crois�s;
    public List<Variables> EnnemisList = new List<Variables>();
    public Variables Ennemis;
    public int IndexList;

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
        Debug.Log("enter");
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
        Debug.Log("exit");
    }
}
