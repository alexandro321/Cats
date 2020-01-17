using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.HelloAR;

public class LoveBar : MonoBehaviour
{
    public HelloARController helloARController;
    public Image bar;
    [HideInInspector]
    public float fill;
    [HideInInspector]
    public float cons;
    [HideInInspector]
    public int coins;
    private Color32 colorBar;
    private Color32 colorBarlast;
    public bool coinsAdded = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Love"))
        {
            PlayerPrefs.SetFloat("Love", 1);
        }
        
        fill = PlayerPrefs.GetFloat("Love");
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            if (fill >= 0.92f & !coinsAdded)
            {
                coins = PlayerPrefs.GetInt("Coins");
                coins += 10;
                PlayerPrefs.SetInt("Coins", coins);
                coinsAdded = true;
            }
            if (fill < 0.92f)
            {
                coinsAdded = false;
            }
        }
            
        fill = (PlayerPrefs.GetFloat("Hunger") + PlayerPrefs.GetFloat("Fun") + PlayerPrefs.GetFloat("IHATEMYLIFE")) / 3;
        cons = 1 - fill; 
        bar.fillAmount = fill;
        colorBarlast = new Color32(126, 255, 245, 255);
        colorBar = new Color32(195, 27, 0, 255);
        bar.color = Color32.Lerp(colorBarlast, colorBar, cons);
        
    }
}
