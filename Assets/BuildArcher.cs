using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildArcher : MonoBehaviour
{
    public GameObject LastButtonClick;
    public GameObject PanelChoixTours;
    public GameObject prefabArcher;
    public Vector2 TourCoo;
    public void onClickBaby()
    {
        GameObject gameObjectSource = GameObject.Find("Plots");
        GestionBoutton gestionboutton = gameObjectSource.GetComponent<GestionBoutton>();
        TourCoo = gestionboutton.PosLastClickButton;
        LastButtonClick = (GameObject)gestionboutton.LastClickButton.gameObject;
        //LastButtonClick = gestionboutton.LastClickButton.gameObject as GameObject;
        GameObject InstanceSpawn = Instantiate(prefabArcher, TourCoo, Quaternion.identity);
        PanelChoixTours.SetActive(false);
        LastButtonClick.SetActive(false);

    }
}
