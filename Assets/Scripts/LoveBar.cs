using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBar : MonoBehaviour
{
    public Image bar;
    [HideInInspector]
    public float fill;
    [HideInInspector]
    public float cons;
    [HideInInspector]
    public int coins;
    private Color32 colorBar;
    private Color32 colorBarlast;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Love"))
        {        }
        else
        {
            PlayerPrefs.SetFloat("Love", 1);
        }
        
        fill = PlayerPrefs.GetFloat("Love");
        
    }

    // Update is called once per frame
    void Update()
    {
        fill = (PlayerPrefs.GetFloat("Hunger") + PlayerPrefs.GetFloat("Fun") + PlayerPrefs.GetFloat("Clean")) / 3;
        cons = 1 - fill; 
        bar.fillAmount = fill;
        colorBarlast = new Color32(126, 255, 245, 255);
        colorBar = new Color32(195, 27, 0, 255);
        bar.color = Color32.Lerp(colorBarlast, colorBar, cons);
        
    }
}
