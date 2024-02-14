using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocusSpawn : MonoBehaviour
{
    public Transform Posblocus;
    public GameObject Chevalier;
    public Transform ParentGameObject;

    public void Start()
    {
        Posblocus = gameObject.GetComponent<Transform>();

        GameObject InstanciateGameobject1 = Instantiate(Chevalier, Posblocus.position, Quaternion.identity);
        GameObject InstanciateGameobject2 = Instantiate(Chevalier, Posblocus.position, Quaternion.identity);
        GameObject InstanciateGameobject3 = Instantiate(Chevalier, Posblocus.position, Quaternion.identity);
        InstanciateGameobject1.transform.parent = ParentGameObject;
        InstanciateGameobject1.name = "1";
        InstanciateGameobject2.transform.parent = ParentGameObject;
        InstanciateGameobject2.name = "2";
        InstanciateGameobject3.transform.parent = ParentGameObject;
        InstanciateGameobject3.name = "3";
        //additionner vecteur si on veut un décalage par rapport à l'origine
    }





   
}
