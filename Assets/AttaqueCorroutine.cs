using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueCorroutine : MonoBehaviour
{
    public Attaque Reff;
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
        Reff = gameObject.GetComponent<Attaque>();
        Enattente = true;
        yield return new WaitForSeconds(2f);

        Reff.Ennemis.Pv -= Reff.Croisés.DegatsMob;

        Enattente = false;

    }
}
