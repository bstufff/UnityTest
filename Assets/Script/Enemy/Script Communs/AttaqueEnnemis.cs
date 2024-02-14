using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AttaqueEnnemis : MonoBehaviour
{
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
            Variables otherVariables = other.GetComponent<Variables>();
            if (otherVariables.Encombat == false) 
            { 
                Crois�sList.Add(otherVariables); 
            }

            if (Crois�sList.Count > 0 && Crois�sList[0].Encombat == false)// null reff exp && le premier crois� est pas en combat
            {
                Crois�s.Add(otherVariables);
            }

            if (Crois�sList.Count > 0 && Crois�sList[0].Encombat == false)// null reff exp && le premier crois� est pas en combat
            {
                Ennemis.Encombat = true;
                Ennemis.Speed = 0;
            }
            // pour encombat
            if (Crois�sList.Count > 0)
            {
                Crois�sList[0].Encombat = true;
                Crois�sList[0].Ensupport = false;
                

                if (Crois�sList.Count >= 2 && Crois�sList[1].Encombat == false)
                {
                    Crois�sList[1].Ensupport = true;
                }

                if (Crois�sList.Count >= 3 && Crois�sList[1].Encombat == false && Crois�sList[2].Encombat == false)
                {
                    Crois�sList[1].Ensupport = true;
                    Crois�sList[2].Ensupport = true;
                }
            }
           

        }
    }
    public void OnTriggerStay2D(Collider2D col) 
    {
        if (Crois�s.Count > 0 && Crois�s[0].Encombat == false)
        {
            Ennemis.Encombat = true;
            Ennemis.Speed = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if ((((int)1 << collision.gameObject.layer) & layerMask) != 0)
        {
            int pos = Crois�sList.IndexOf(collision.GetComponent<Variables>());
            float SpeedB = gameObject.GetComponent<Variables>().SpeedB;
            if (Crois�s.Count > 0)
            {
                Crois�s.RemoveAt(0);
                
            }
            Crois�sList.RemoveAt(pos);
            if (Crois�s.Count == 0 && Ennemis.Encombat == true)
            {
                Ennemis.Encombat = false;
            }
            List<Variables> OK = new List<Variables>();
            foreach(Variables v in Crois�sList) 
            {
                if (v != null) 
                { 
                    OK.Add(v);
                }
            }
            Crois�sList = OK;
            if (Crois�sList.Count == 0)
            {
                Ennemis.Speed = SpeedB;
            }
        }
    }
    public void Refresh()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(gameObject);
#endif
    }











}
