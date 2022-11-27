using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverColor : MonoBehaviour
{
    public Button button;
    public Color textWantedColor;
    public Color panelWantedColor;
    private Color textOriginalColor;
    private Color panelOriginalColor;

    public Image panel, image;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {    
        textOriginalColor = text.color;
        panelOriginalColor = panel.color;
    }

    public void changeWhenHover(){
        text.color = textWantedColor;
        image.color = textWantedColor;
        panel.color = panelWantedColor;    
    }

    public void changeWhenLeft(){
        text.color = textOriginalColor;
        image.color = textOriginalColor;
        panel.color = panelOriginalColor;
    }


}
