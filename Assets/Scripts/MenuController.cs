using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleARCore.Examples.HelloAR;

public class MenuController : MonoBehaviour
{
    public HelloARController helloARController;
    public bool isShown;
    // Start is called before the first frame update
    void Start()
    {
        isShown = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMove()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        if (helloARController.catIsPlaced == true)
        {
            GameObject cat = GameObject.FindGameObjectWithTag("work cat");
            GameObject trueCat = GameObject.FindGameObjectWithTag("true cat");
            CatBehavior catBehavior = trueCat.GetComponent<CatBehavior>();

            Run run = cat.GetComponent<Run>();
            Debug.Log(run.isActiveAndEnabled);
            if (run.isActiveAndEnabled)
            {
                run.enabled = false;
                isShown = true;
                catBehavior.catAnimator.SetTrigger("idle");
            }
            else
            {
                run.enabled = true;
                isShown = false;
                catBehavior.catAnimator.SetTrigger("walk");
            }

        }
        
    }

    void OnApplicationQuit() {

        if(PlayerPrefs.GetString("Is Dead") == "alive")
        {
            Debug.Log("App was quit");
            Debug.Log("ЧИСТОТА");
            PlayerPrefs.SetInt("LastEnterYear", DateTime.Now.Year);
            PlayerPrefs.SetInt("LastEnterMonth", DateTime.Now.Month);
            PlayerPrefs.SetInt("LastEnterDay", DateTime.Now.Day);
            PlayerPrefs.SetInt("LastEnterHour", DateTime.Now.Hour);
            PlayerPrefs.SetInt("LastEnterMinute", DateTime.Now.Minute);
            PlayerPrefs.SetInt("LastEnterSecond", DateTime.Now.Second);

            PlayerPrefs.Save();

        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
        
        
    }
}
