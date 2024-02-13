using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Attaque : MonoBehaviour
{
    
    public Variables Crois�s;
    public List<Variables> EnnemisList = new List<Variables>();
    public Variables Ennemis;
    public int IndexList;
    public float SpeedB;

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        EnnemisList.Add(other.GetComponent<Variables>());
        IndexList = EnnemisList.IndexOf(other.GetComponent<Variables>());   
        Crois�s = GetComponent<Variables>();
        Ennemis = EnnemisList[0];
        if(Crois�s.Ensupport == true)// si le crois� est en support
        {
            Debug.Log("SUPPORT TRUE");
            Ennemis = EnnemisList[IndexList];
            Ennemis.Speed = 0f;
            if (EnnemisList.Count >= 2) 
            {
                Crois�s.Ensupport = false;
                Crois�s.Encombat = true;
            }

        }
        Ennemis.Pv -= Crois�s.DegatsMob;
        if (Crois�s.Encombat == false || Crois�s.Ensupport == false) // si le crois� n'encore rien rencontr�
        {
            SpeedB = Crois�s.Speed;
            Crois�s.Speed = 0f;
        }
    }   
    public void OnTriggerExit2D(Collider2D collision)
    {
        IndexList = EnnemisList.IndexOf(collision.GetComponent<Variables>());
        EnnemisList.RemoveAt(IndexList);
        Refresh();
        if(EnnemisList.Count != 0)//si il reste un ennemis
        {
            Crois�s.Encombat = false;
            Crois�s.Ensupport = true;
            Ennemis = EnnemisList[0];
        } 
        if(EnnemisList.Count == 0)//si il n'y a plus d'ennemis
        {
            Crois�s.Encombat = false;
            Crois�s.Ensupport = false;
        }
        Crois�s.Speed = SpeedB;
    }
    public void Refresh()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(gameObject);
#endif
    }
}
