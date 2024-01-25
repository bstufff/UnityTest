using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionBoutton : MonoBehaviour
{
    public Button LastClickButton;
    public Vector2 PosLastClickButton;
    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons) 
        { 
            button.onClick.AddListener(() => ClicSurBouton(button));
        }
    }
    public void ClicSurBouton(Button boutonclique) 
    { 
        RectTransform rectTransform = boutonclique.GetComponent<RectTransform>();
        PosLastClickButton = rectTransform.position;
        LastClickButton = boutonclique;
    }
}
