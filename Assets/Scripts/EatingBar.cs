using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingBar : MonoBehaviour
{

    public Image bar;
    public float fill;
    public float cons;
    private Color32 colorBar;
    private Color32 colorBarlast;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fill > 0 )
        {
            fill -= Time.deltaTime * 0.05f;
            cons = 1 - fill; 

            bar.fillAmount = fill;

            colorBarlast = new Color32(126, 255, 245, 255);
            colorBar = new Color32(195, 27, 0, 255);
            bar.color = Color32.Lerp(colorBarlast, colorBar, cons);
                
        }

        Debug.Log(bar.color);
    }

    public void Change()
    {
        if (fill < 1)
            fill += 0.2f;
    }

}
