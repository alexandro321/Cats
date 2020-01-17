using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleARCore.Examples.HelloAR;

public class CleanBar : MonoBehaviour
{
    public HelloARController helloARController;
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

    // GameObject cat;
    // CatBehavior catBehavior;
    public string status;
    public GameObject notice;
    bool messageShown = false;



    void Start()
    {
        status = "idle";
        currentFill = PlayerPrefs.GetFloat("IHATEMYLIFE");

        if (PlayerPrefs.HasKey("IHATEMYLIFE"))
        {      
            DateTime LastEnterTime = new DateTime(
                PlayerPrefs.GetInt("LastEnterYear", DateTime.Now.Year), 
                PlayerPrefs.GetInt("LastEnterMonth", DateTime.Now.Month), 
                PlayerPrefs.GetInt("LastEnterDay", DateTime.Now.Day),
                PlayerPrefs.GetInt("LastEnterHour", DateTime.Now.Hour), 
                PlayerPrefs.GetInt("LastEnterMinute", DateTime.Now.Minute), 
                PlayerPrefs.GetInt("LastEnterSecond", DateTime.Now.Second)
            );

            decFill = (float)(DateTime.Now - LastEnterTime).TotalMinutes*0.01f; //CHANGE TO 0.001f ON RELEASE

            if(decFill > currentFill){
                PlayerPrefs.SetFloat("IHATEMYLIFE", 0);
            }
            else {
                PlayerPrefs.SetFloat("IHATEMYLIFE", currentFill - decFill);
            }

        }
        else
        {
            PlayerPrefs.SetFloat("IHATEMYLIFE", 1);
        }

        if (PlayerPrefs.HasKey("LitterBox")){
        }
        else {
            PlayerPrefs.SetString("LitterBox", "clean");
        }        
        
        fill = PlayerPrefs.GetFloat("IHATEMYLIFE");
        Debug.Log("ЧИСТОТА");
        Debug.Log(fill);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bar.fillAmount = fill;
        if (fill > 0 )
        {
            fill -= Time.deltaTime * 0.01f; // CHANGE TO 0.001f ON RELEASE
            cons = 1 - fill; 
            bar.fillAmount = fill;
            colorBarlast = new Color32(126, 255, 245, 255);
            colorBar = new Color32(195, 27, 0, 255);
            bar.color = Color32.Lerp(colorBarlast, colorBar, cons);
                
        }

        if(fill < 0.5f){
            PlayerPrefs.SetString("LitterBox", "dirty");            
        }

        PlayerPrefs.SetFloat("IHATEMYLIFE", fill);
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

    public void  WashCat()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            GameObject trueCat = GameObject.FindGameObjectWithTag("true cat");
            CatBehavior catBehavior = trueCat.GetComponent<CatBehavior>();


            if (PlayerPrefs.GetString("LitterBox") == "clean" & fill < 0.8)
            {
                fill = 1;
                //status = "wash";
                catBehavior.catAnimator.SetTrigger("wash");
            }
            else if (PlayerPrefs.GetString("LitterBox") == "dirty" & fill < 0.75f)
            {
                fill = 0.75f;
                catBehavior.catAnimator.SetTrigger("wash");
                //status = "wash";

            }

            PlayerPrefs.SetFloat("IHATEMYLIFE", fill);
            PlayerPrefs.Save();
        }

        
            
    }

    public void  ChangeCatLitter()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            coins = PlayerPrefs.GetInt("Coins");
            if (fill < 0.8f & PlayerPrefs.GetString("LitterBox") == "dirty")
            {
                if (coins >= 10)
                {
                    coins -= 10;
                    if (fill < 0.5)
                    {
                        fill = 0.6f;
                    }
                    else if (fill >= 0.5f & fill <= 0.73f)
                    {
                        fill += 0.27f;
                    }
                    else
                    {
                        fill = 1;
                    }

                    PlayerPrefs.SetString("LitterBox", "clean");
                    PlayerPrefs.SetInt("Coins", coins);
                    PlayerPrefs.Save();
                }
            }

        }
        
            
    }
}
