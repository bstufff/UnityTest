using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PVGui : MonoBehaviour
{
    public TextMeshProUGUI pvText;
    // Start is called before the first frame update
    void Start()
    {
        pvText = GetComponent<TextMeshProUGUI>();
        if (pvText != null)
        {
            pvText.text = FindObjectOfType<VariableChateauEtGameOver>().Pv.ToString();
        }

    }
}
