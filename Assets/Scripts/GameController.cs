using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text inputName;
    public GameObject inputField;

    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Cat name"))
        {
            StartGame();
        }
    }


    public void StartGame()
    {
        inputField.SetActive(false);
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        SceneManager.LoadScene("HelloAR");
    }

    public void GameAfter()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Cat name", inputName.text);
        Debug.Log(PlayerPrefs.GetString("Cat name"));
        if(PlayerPrefs.GetString("Cat name") != ""){
            StartGame();
        }
        else{
            Debug.Log("Empty name");
        }
        
    }

}
