using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleARCore.Examples.HelloAR;

public class FunBar : MonoBehaviour
{
    public HelloARController helloARController;
    public Image bar;
    [HideInInspector]
    public float fill;

    [HideInInspector]
    public float currentFill;
    [HideInInspector]
    public float decFill;
    [HideInInspector]
    public float cons;
    [HideInInspector]
    public int coins;
    private Color32 colorBar;
    private Color32 colorBarlast;
    public GameObject notice;
    bool messageShown = false;

    void Start()
    {if (PlayerPrefs.HasKey("Fun"))
        {
            currentFill = PlayerPrefs.GetFloat("Fun");

            DateTime LastEnterTime = new DateTime(
                PlayerPrefs.GetInt("LastEnterYear", DateTime.Now.Year), 
                PlayerPrefs.GetInt("LastEnterMonth", DateTime.Now.Month), 
                PlayerPrefs.GetInt("LastEnterDay", DateTime.Now.Day),
                PlayerPrefs.GetInt("LastEnterHour", DateTime.Now.Hour), 
                PlayerPrefs.GetInt("LastEnterMinute", DateTime.Now.Minute), 
                PlayerPrefs.GetInt("LastEnterSecond", DateTime.Now.Second)
            );

            decFill = (float)(DateTime.Now - LastEnterTime).TotalMinutes*0.005f; //CHANGE TO 0.0005f ON RELEASE

            if(decFill > currentFill){
                PlayerPrefs.SetFloat("Fun", 0);
            }
            else {
                PlayerPrefs.SetFloat("Fun", currentFill - decFill);
            }

        }
        else
        {
            PlayerPrefs.SetFloat("Fun", 1);
        }
        
        fill = PlayerPrefs.GetFloat("Fun");
        
    }

    void Update()
    {
        bar.fillAmount = fill;
        if (fill > 0 )
        {
            fill -= Time.deltaTime * 0.01f; // 0.0005f;
            cons = 1 - fill; 
            bar.fillAmount = fill;
            colorBarlast = new Color32(126, 255, 245, 255);
            colorBar = new Color32(195, 27, 0, 255);
            bar.color = Color32.Lerp(colorBarlast, colorBar, cons);
                
        }

        PlayerPrefs.SetFloat("Fun", fill);

        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            if (fill <= 0.25f & PlayerPrefs.GetFloat("Hunger") > 0 & !messageShown)
            {
                notice.SetActive(true);
                messageShown = true;
            }
            if (fill > 0.25f)
            {
                messageShown = false;
            }

        }
        

    }
    public void  Play()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            coins = PlayerPrefs.GetInt("Coins");
            if (coins >= 3)
            {
                
                if (fill < 0.87f)
                {
                    GameObject trueCat = GameObject.FindGameObjectWithTag("true cat");
                    CatBehavior catBehavior = trueCat.GetComponent<CatBehavior>();
                    catBehavior.catAnimator.SetTrigger("play");

                    if (fill <= 0.73f)
                    {
                        fill += 0.27f;
                    }
                    else
                    {
                        fill = 1;
                    }
                    coins -= 3;
                }

                PlayerPrefs.SetInt("Coins", coins);
                PlayerPrefs.Save();

            }

        }

                   
    }
}
