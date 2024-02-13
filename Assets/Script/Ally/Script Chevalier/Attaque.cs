using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Attaque : MonoBehaviour
{
    
    public Variables Croisés;
    public List<Variables> EnnemisList = new List<Variables>();
    public Variables Ennemis;
    public int IndexList;
    public float SpeedB;

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        EnnemisList.Add(other.GetComponent<Variables>());
        IndexList = EnnemisList.IndexOf(other.GetComponent<Variables>());   
        Croisés = GetComponent<Variables>();
        Ennemis = EnnemisList[0];
        if(Croisés.Ensupport == true)// si le croisé est en support
        {
            Debug.Log("SUPPORT TRUE");
            Ennemis = EnnemisList[IndexList];
            Ennemis.Speed = 0f;
            if (EnnemisList.Count >= 2) 
            {
                Croisés.Ensupport = false;
                Croisés.Encombat = true;
            }

        }
        Ennemis.Pv -= Croisés.DegatsMob;
        if (Croisés.Encombat == false || Croisés.Ensupport == false) // si le croisé n'encore rien rencontré
        {
            SpeedB = Croisés.Speed;
            Croisés.Speed = 0f;
        }
    }   
    public void OnTriggerExit2D(Collider2D collision)
    {
        IndexList = EnnemisList.IndexOf(collision.GetComponent<Variables>());
        EnnemisList.RemoveAt(IndexList);
        Refresh();
        if(EnnemisList.Count != 0)//si il reste un ennemis
        {
            Croisés.Encombat = false;
            Croisés.Ensupport = true;
            Ennemis = EnnemisList[0];
        } 
        if(EnnemisList.Count == 0)//si il n'y a plus d'ennemis
        {
            Croisés.Encombat = false;
            Croisés.Ensupport = false;
        }
        Croisés.Speed = SpeedB;
    }
    public void Refresh()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(gameObject);
#endif
    }
}
