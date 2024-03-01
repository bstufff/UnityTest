using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlowingTower : MonoBehaviour
{
    public GameObject LastButtonClick;
    public GameObject PanelChoixTours;
    public GameObject prefabSlowingTower;
    public Vector2 TourCoo;
    public int towerCost = 300;
    public void onClickBaby()
    {
        MoneyScript moneyScript = FindObjectOfType<LevelManager>().GetComponent<MoneyScript>();
        if (moneyScript != null)
        {
            if (moneyScript.money >= towerCost)
            {
                moneyScript.money -= towerCost;
                GameObject gameObjectSource = GameObject.Find("Plots");
                GestionBoutton gestionboutton = gameObjectSource.GetComponent<GestionBoutton>();
                TourCoo = gestionboutton.PosLastClickButton;
                LastButtonClick = (GameObject)gestionboutton.LastClickButton.gameObject;
                //LastButtonClick = gestionboutton.LastClickButton.gameObject as GameObject;
                GameObject InstanceSpawn = Instantiate(prefabSlowingTower, TourCoo, Quaternion.identity);
                PanelChoixTours.SetActive(false);
                LastButtonClick.SetActive(false);

            }
            else
            {
                Debug.Log("Pas assez d'argent !");
            }

        }
        else
        {
            Debug.Log("Aucun LevelManager détecté !");
        }


    }
}
