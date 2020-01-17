using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleARCore.Examples.HelloAR;

public class EatingBar : MonoBehaviour
{
    public HelloARController helloARController;
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
    public GameObject miniCanvas;
    public GameObject buttons;
    public GameObject info;
    public GameObject notice;
    bool messageShown = false;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Is Dead")) { }
        else
        {
            PlayerPrefs.SetString("Is Dead", "alive");
        }
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

            decFill = (float)(DateTime.Now - LastEnterTime).TotalMinutes* 0.005f; //CHANGE TO 0.001f ON RELEASE
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

        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();

        
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
        
        else {
            if(helloARController.catIsPlaced)
            {
                GameObject trueCat = GameObject.FindGameObjectWithTag("true cat");
                CatBehavior catBehavior = trueCat.GetComponent<CatBehavior>();
                catBehavior.catAnimator.SetTrigger("death");
                PlayerPrefs.SetString("Is Dead", "dead");
                info.SetActive(true);
                miniCanvas.SetActive(false);
                buttons.SetActive(false);

            }           

        }
        PlayerPrefs.SetFloat("Hunger", fill);

        
        if (helloARController.catIsPlaced)
        {
            if (fill <= 0.25f & PlayerPrefs.GetString("Is Dead") != "dead" & !messageShown)
            {
                notice.SetActive(true);
                messageShown = true;
            }
            if (fill > 0.25f)
            {
                messageShown = false;
            }

        }
        
        
        //Debug.Log(bar.color);
        
    }

    public void Feed()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            coins = PlayerPrefs.GetInt("Coins");
            if (fill < 0.87f)
            {
                if (coins >= 5)
                {
                    coins -= 5;
                    fill = 1;
                    PlayerPrefs.SetInt("Coins", coins);
                    PlayerPrefs.Save();
                }
            }

        }

            
    }

    //public void QuitGame()
    //{
    //    PlayerPrefs.SetInt("LastEnterYear", DateTime.Now.Year);
    //    PlayerPrefs.SetInt("LastEnterMonth", DateTime.Now.Month);
    //    PlayerPrefs.SetInt("LastEnterDay", DateTime.Now.Day);
    //    PlayerPrefs.SetInt("LastEnterHour", DateTime.Now.Hour);
    //    PlayerPrefs.SetInt("LastEnterMinute", DateTime.Now.Minute);
    //    PlayerPrefs.SetInt("LastEnterSecond", DateTime.Now.Second);

    //    PlayerPrefs.Save();
    //    Application.Quit();
    //}    

}
