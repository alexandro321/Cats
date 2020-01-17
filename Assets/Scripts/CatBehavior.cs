using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    public Animator catAnimator;
    public string animStatus;
    public GameObject cb;
    public CleanBar cleanBar;
    public MenuController menuController;
    
    void Start()
    {
        cb = GameObject.FindGameObjectWithTag("clean bar");
        cleanBar = cb.GetComponent<CleanBar>();
        menuController = cb.GetComponent<MenuController>();
        animStatus = "idle";
        
    }

    void Update()
    {
       

    }

    
}
