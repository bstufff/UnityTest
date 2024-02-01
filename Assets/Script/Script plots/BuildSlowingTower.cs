using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlowingTower : MonoBehaviour
{
    public GameObject LastButtonClick;
    public GameObject PanelChoixTours;
    public GameObject prefabSlowingTower;
    public Vector2 TourCoo;
    public void onClickBaby()
    {
        GameObject gameObjectSource = GameObject.Find("Plots");
        GestionBoutton gestionboutton = gameObjectSource.GetComponent<GestionBoutton>();
        TourCoo = gestionboutton.PosLastClickButton;
        LastButtonClick = (GameObject)gestionboutton.LastClickButton.gameObject;
        //LastButtonClick = gestionboutton.LastClickButton.gameObject as GameObject;
        GameObject InstanceSpawn = Instantiate(prefabSlowingTower, TourCoo, Quaternion.identity);
        PanelChoixTours.SetActive(false);
        LastButtonClick.SetActive(false);

    }
}
