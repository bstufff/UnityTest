using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mort : MonoBehaviour
{
    //public VariablesGold MontantGold;
    public Variables enemy;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        enemy = GetComponent<Variables>();
    }

    private void Update()
    {
        //MontantGold = GetComponent<VariablesGold>();
        if (enemy != null && enemy.Pv <= 0)
        {
            spriteRenderer.enabled = false;
            StartCoroutine(DelaiDie());
            MoneyScript moneyScript = FindObjectOfType<LevelManager>().GetComponent<MoneyScript>();//récupère l'argent que possède le joueur
            if (moneyScript != null )
            {
                moneyScript.money += enemy.ValeurGold;
            }
            Destroy(gameObject);
        }
        IEnumerator DelaiDie() 
        { 
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    }
}
