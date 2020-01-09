using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpendCoin : MonoBehaviour
{

    public int coins;
    public Text coin;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("Coins", 60);    
        }
        coins = PlayerPrefs.GetInt("Coins");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
