using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CleanBar : MonoBehaviour
{
    
    public Image bar;
    [HideInInspector]
    public float fill;
    [HideInInspector]
    public float cons;
    [HideInInspector]
    public int coins;
    [HideInInspector]
    public float currentFill;
    [HideInInspector]
    public float decFill;
    private Color32 colorBar;
    private Color32 colorBarlast;

    void Start()
    {if (PlayerPrefs.HasKey("Clean"))
        {
            currentFill = PlayerPrefs.GetFloat("Clean");

            DateTime LastEnterTime = new DateTime(
                PlayerPrefs.GetInt("LastEnterYear", DateTime.Now.Year), 
                PlayerPrefs.GetInt("LastEnterMonth", DateTime.Now.Month), 
                PlayerPrefs.GetInt("LastEnterDay", DateTime.Now.Day),
                PlayerPrefs.GetInt("LastEnterHour", DateTime.Now.Hour), 
                PlayerPrefs.GetInt("LastEnterMinute", DateTime.Now.Minute), 
                PlayerPrefs.GetInt("LastEnterSecond", DateTime.Now.Second)
            );

            decFill = (float)(DateTime.Now - LastEnterTime).TotalMinutes*0.5f; //CHANGE TO 0.001f ON RELEASE

            if(decFill > currentFill){
                PlayerPrefs.SetFloat("Clean", 0);
            }
            else {
                PlayerPrefs.SetFloat("Clean", currentFill - decFill);
            }

        }
        else
        {
            PlayerPrefs.SetFloat("Clean", 1);
        }
        
        fill = PlayerPrefs.GetFloat("Clean");
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = fill;
        if (fill > 0 )
        {            
            fill -= Time.deltaTime * 0.01f;
            cons = 1 - fill; 
            bar.fillAmount = fill;
            colorBarlast = new Color32(126, 255, 245, 255);
            colorBar = new Color32(195, 27, 0, 255);
            bar.color = Color32.Lerp(colorBarlast, colorBar, cons);
                
        }
        PlayerPrefs.SetFloat("Clean", fill);
        
    }
    public void  WashCat()
    {
        if (fill < 0.75f){
                fill = 0.75f;         
        }
            
    }

    public void  ChangeCatLitter()
    {
        coins = PlayerPrefs.GetInt("Coins");
        if (fill < 1){
            if(coins >= 10){
                coins -= 10;
                fill += 0.25f;
                PlayerPrefs.SetInt("Coins", coins);
                PlayerPrefs.Save();
            }       
        }
            
    }
}
