using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EatingBar : MonoBehaviour
{

    public Image bar;
    [HideInInspector]
    public float fill;
    [HideInInspector]
    public float cons;
    [HideInInspector]
    public float currentFill;
    [HideInInspector]
    public float decFill;
    [HideInInspector]
    public int coins;
    private Color32 colorBar;
    private Color32 colorBarlast;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hunger"))
        {
            currentFill = PlayerPrefs.GetFloat("Hunger");

            //Debug.Log("currentFill" + currentFill);

            DateTime LastEnterTime = new DateTime(
                PlayerPrefs.GetInt("LastEnterYear", DateTime.Now.Year), 
                PlayerPrefs.GetInt("LastEnterMonth", DateTime.Now.Month), 
                PlayerPrefs.GetInt("LastEnterDay", DateTime.Now.Day),
                PlayerPrefs.GetInt("LastEnterHour", DateTime.Now.Hour), 
                PlayerPrefs.GetInt("LastEnterMinute", DateTime.Now.Minute), 
                PlayerPrefs.GetInt("LastEnterSecond", DateTime.Now.Second)
            );

            decFill = (float)(DateTime.Now - LastEnterTime).TotalMinutes*0.5f; //CHANGE TO 0.001f ON RELEASE
            //Debug.Log("decFill" + decFill);

            if(decFill > currentFill){
                PlayerPrefs.SetFloat("Hunger", 0);
            }
            else {
                PlayerPrefs.SetFloat("Hunger", currentFill - decFill);
            }

            //Debug.Log("Прошло времени " + (float)(DateTime.Now - LastEnterTime).TotalMinutes*0.02f);

        }
        else
        {
            PlayerPrefs.SetFloat("Hunger", 1);
        }
        
        fill = PlayerPrefs.GetFloat("Hunger");
    }

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
        PlayerPrefs.SetFloat("Hunger", fill);
        //Debug.Log(bar.color);
        
    }

    public void Feed()
    {
        coins = PlayerPrefs.GetInt("Coins");
        if (fill < 1)
            if(coins >= 5){
                coins -= 5;
                fill = 1;
                PlayerPrefs.SetInt("Coins", coins);
                PlayerPrefs.Save();
            }            
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("LastEnterYear", DateTime.Now.Year);
        PlayerPrefs.SetInt("LastEnterMonth", DateTime.Now.Month);
        PlayerPrefs.SetInt("LastEnterDay", DateTime.Now.Day);
        PlayerPrefs.SetInt("LastEnterHour", DateTime.Now.Hour);
        PlayerPrefs.SetInt("LastEnterMinute", DateTime.Now.Minute);
        PlayerPrefs.SetInt("LastEnterSecond", DateTime.Now.Second);

        PlayerPrefs.Save();
        Application.Quit();
    }    

}
