using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Héros : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private int Hitpoints = 20;
    [SerializeField] private int Damage = 5;
    [SerializeField] private float ATS = 5; //attack speed

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMouvementVectorNormalized();

        
    }

    public void DealDamage()
    {
      //  if ()  
      //  { 

       // }
        //player click ou range avec attaque auto ? sur monstre alors on applique les dégats

    }

    public void TakeDamage()
    {


    }








}
