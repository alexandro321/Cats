using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    { 
        
    }
    public void StartGame()
    {
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

}
