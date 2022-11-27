using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHoverColor : MonoBehaviour
{
    public Button button;
    public Color textWantedColor;
    public Color panelWantedColor;
    private Color textOriginalColor;
    private Color panelOriginalColor;

    public Image panel, line, handle;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {    
        textOriginalColor = text.color;
        panelOriginalColor = panel.color;
    }

    public void changeWhenHover(){
        text.color = textWantedColor;
        panel.color = panelWantedColor;    
        line.color = Color.white;
        handle.color = Color.white;
    }

    public void changeWhenLeft(){
        text.color = textOriginalColor;
        panel.color = panelOriginalColor;
        line.color = textOriginalColor;
        handle.color = textOriginalColor;
        
    }

}
