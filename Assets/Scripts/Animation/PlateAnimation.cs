using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateAnimation : MonoBehaviour
{
    public Animator plateAnimator;
    private string state;
    void Start()
    {
        state = "full";
        plateAnimator.SetTrigger("full");
        //plateAnimator = gameObject.GetComponent<Animator>();
        //Debug.Log("ААААААААААА");
       // Debug.Log(plateAnimator);
    }

    void Update()
    {
        if(PlayerPrefs.GetFloat("Hunger") <= 0.5f & state == "full"){
            Debug.Log("empty");
            plateAnimator.ResetTrigger("full");
            plateAnimator.SetTrigger("empty");
            state = "empty";
        }
        if(PlayerPrefs.GetFloat("Hunger") > 0.5f & state == "empty") {
            Debug.Log("full");
            plateAnimator.ResetTrigger("empty");
            plateAnimator.SetTrigger("full");
            state = "full";
        }
        
    }
}
