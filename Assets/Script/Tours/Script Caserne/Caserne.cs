using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Caserne : MonoBehaviour
{
    public Transform Poscaserne;
    public GameObject Chevalier;
    public SpriteRenderer RangeTour;
   
    public void Start()
    {
        Poscaserne = GetComponent<Transform>();
        Instantiate(Chevalier, Poscaserne.position ,Quaternion.identity);
        Instantiate(Chevalier, Poscaserne.position , Quaternion.identity);
        Instantiate(Chevalier, Poscaserne.position, Quaternion.identity);
        //additionner vecteur si on veut un décalage par rapport à l'origine

    }

  

    public void OnTriggerStay2D(Collider2D collision)
    {
     

        


        
    }




}
