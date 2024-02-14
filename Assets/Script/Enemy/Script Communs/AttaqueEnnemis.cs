using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AttaqueEnnemis : MonoBehaviour
{
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
            Debug.Log("exe");
            Ennemis = GetComponent<Variables>();
            Variables otherVariables = other.GetComponent<Variables>();

            CroisésList.Add(otherVariables);

            if (CroisésList.Count > 0 && CroisésList[0].Encombat == false)// null reff exp && le premier croisé est pas en combat
            {
                Croisés.Add(otherVariables);
            }

            if (CroisésList.Count > 0 && CroisésList[0].Encombat == false)// null reff exp && le premier croisé est pas en combat
            {
                Debug.LogWarning("SUPPORT TRUE");
                Ennemis.Encombat = true;
                Ennemis.Speed = 0;
            }

            if (CroisésList.Count > 0)
            {
                CroisésList[0].Encombat = true;
                if (Croisés.Count > 0) 
                { 
                    Croisés[0].Pv -= Ennemis.DegatsMob; 
                }
                

                if (CroisésList.Count >= 2 && CroisésList[1].Encombat == false)
                {
                    CroisésList[1].Ensupport = true;
                }

                if (CroisésList.Count >= 3 && CroisésList[1].Encombat == false && CroisésList[2].Encombat == false)
                {
                    CroisésList[1].Ensupport = true;
                    CroisésList[2].Ensupport = true;
                }
            }

        }
    }
    public void OnTriggerStay2D(Collider2D col) 
    {
        if (Croisés.Count > 0 && Croisés[0].Encombat == false)
        {
            Ennemis.Encombat = true;
            Ennemis.Speed = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if ((((int)1 << collision.gameObject.layer) & layerMask) != 0)
        {
            int pos = CroisésList.IndexOf(collision.GetComponent<Variables>());
            float SpeedB = gameObject.GetComponent<Variables>().SpeedB;
            if (Croisés.Count > 0)
            {
                Croisés.RemoveAt(0);
                Refresh();
            }
            CroisésList.RemoveAt(pos);
            Refresh();
            if (Croisés.Count == 0 && Ennemis.Encombat == true)
            {
                Ennemis.Encombat = false;
            }
            Ennemis.Speed = SpeedB;

            

        }



       
    }
    public void Refresh()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(gameObject);
#endif
    }











}
