using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEnnemis : MonoBehaviour
{
    Variables Ennemis;
    public List<Variables> Crois�sList = new List<Variables>();
    public List<Variables> Crois�s = new List<Variables>();
    private bool Enattente = false;

    public void OnTriggerEnter2D(Collider2D other)
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
            Ennemis.Speed = 0;
        }
        Crois�s[0].Encombat = true;
        Crois�s[0].Pv -= Ennemis.DegatsMob;
        if (Crois�s.Count == 2) 
        { 
            Crois�s[1].Ensupport = true;

        }
        if(Crois�s.Count == 3)
        {
            Crois�s[1].Ensupport = true;//OPTIONNEL
            Crois�s[2].Ensupport = true;
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
        Crois�s.RemoveAt(0);


    }

    IEnumerator Attack()
    {
        Enattente = true;
        yield return new WaitForSeconds(2f);

        Crois�s[0].Pv -= Ennemis.DegatsMob;

        Enattente = false;

    }










}
