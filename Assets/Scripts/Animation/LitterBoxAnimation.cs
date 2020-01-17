using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterBoxAnimation : MonoBehaviour
{
    public Animator boxAnimator;
    private string state;

    void Start()
    {
        if(PlayerPrefs.GetString("LitterBox") == "clean"){
            Debug.Log("clean");
            //boxAnimator.ResetTrigger("dirty");
            //boxAnimator.SetTrigger("clean");
            state = "clean";
        }
        else if(PlayerPrefs.GetString("LitterBox") == "dirty"){
            Debug.Log("dirty");
            //boxAnimator.ResetTrigger("clean");
            //boxAnimator.SetTrigger("dirty");
            state = "dirty";
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("LitterBox") == "clean" & state == "dirty"){
            Debug.Log("clean");
            boxAnimator.ResetTrigger("dirty");
            boxAnimator.SetTrigger("clean");
            state = "clean";
        }
        else if(PlayerPrefs.GetString("LitterBox") == "dirty" & state == "clean"){
            Debug.Log("dirty");
            boxAnimator.ResetTrigger("clean");
            boxAnimator.SetTrigger("dirty");
            state = "dirty";
        }
        
    }
}
