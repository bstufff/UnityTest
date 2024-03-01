using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        if (moneyText != null) {
            moneyText.text = FindObjectOfType<LevelManager>().GetComponent<MoneyScript>().money.ToString();
        }
        
    }
}
