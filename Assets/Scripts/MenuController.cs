using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit() {
        Debug.Log("App was quit");
        PlayerPrefs.SetInt("LastEnterYear", DateTime.Now.Year);
        PlayerPrefs.SetInt("LastEnterMonth", DateTime.Now.Month);
        PlayerPrefs.SetInt("LastEnterDay", DateTime.Now.Day);
        PlayerPrefs.SetInt("LastEnterHour", DateTime.Now.Hour);
        PlayerPrefs.SetInt("LastEnterMinute", DateTime.Now.Minute);
        PlayerPrefs.SetInt("LastEnterSecond", DateTime.Now.Second);

        PlayerPrefs.Save();
        
    }
}
