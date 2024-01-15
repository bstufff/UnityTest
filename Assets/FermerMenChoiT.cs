using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermerMenChoiT : MonoBehaviour
{
    public GameObject PanelChoixTours;
    public void ClosePannelChoixT()
    {
        PanelChoixTours.SetActive(false);
    }
}
