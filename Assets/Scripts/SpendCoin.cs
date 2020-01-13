using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SpendCoin : MonoBehaviour
{

    public int coins;
    public Text coin;
    //public int a;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            
        }
        else
        {
            PlayerPrefs.SetInt("Coins", 50);    
        }
        
        coins = int.Parse(coin.text);

        coins = PlayerPrefs.GetInt("Coins");

        if (PlayerPrefs.HasKey("RewardedYear"))
        {
            DateTime RewardedTime = new DateTime(
                PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), 
                PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), 
                PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
                PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), 
                PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), 
                PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));

            Debug.Log(RewardedTime);
            Debug.Log(" ");
            Debug.Log(DateTime.Now);
            Debug.Log("Текст " + (RewardedTime <= DateTime.Now));
            if ((DateTime.Now - RewardedTime).TotalHours > 23)
            {
                Debug.Log(" ");
                Debug.Log(coins);
                coins += 3;
                Debug.Log(coins);

                UpdateDate();
            }
        }
        else
        {
            UpdateDate();
        }
        
    }

    private void UpdateDate()
    {
        PlayerPrefs.SetInt("RewardedYear", DateTime.Now.Year);
        PlayerPrefs.SetInt("RewardedMonth", DateTime.Now.Month);
        PlayerPrefs.SetInt("RewardedDay", DateTime.Now.Day);
        PlayerPrefs.SetInt("RewardedHour", DateTime.Now.Hour);
        PlayerPrefs.SetInt("RewardedMinute", DateTime.Now.Minute);
        PlayerPrefs.SetInt("RewardedSecond", DateTime.Now.Second);
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = coins.ToString();

        PlayerPrefs.SetInt("Coins", coins);



        PlayerPrefs.Save();
    }

    public void Change()
    {
        if (coins > 0)
            coins -= 2;
    }
}
