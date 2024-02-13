using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttaqueEnnemisCorroutine : MonoBehaviour
{
    public AttaqueEnnemis Reff;
    public bool Enattente = false;
    public void OnTriggerStay2D(Collider2D collision)
    {

        if (!Enattente)
        {
            StartCoroutine(Attack());
        }

    }
    public IEnumerator Attack()
    {
        Reff = gameObject.GetComponent<AttaqueEnnemis>();
        Enattente = true;
        yield return new WaitForSeconds(2f);
        if (Reff.Croisés.Count > 0) 
        {
            Reff.Croisés[0].Pv -= Reff.Ennemis.DegatsMob;
        }

        Enattente = false;

    }
}
