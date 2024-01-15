using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildArcher : MonoBehaviour
{
    public Vector2 TourCoo;
    public void Start()
    {
        GameObject gameObjectSource = GameObject.Find("Plots");
        GestionBoutton gestionboutton = gameObjectSource.GetComponent<GestionBoutton>();
        TourCoo = gestionboutton.PosLastClickButton;
    }
    [Header("References")]
    [SerializeField] public GameObject[] towerprefabs;
}
