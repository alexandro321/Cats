using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShow : MonoBehaviour
{
    GameObject character;
    MenuController menuController;
    bool status;
    // Start is called before the first frame update
    void Start()
    {
        status = true;
        character = GameObject.Find("Character");
        menuController = character.GetComponent<MenuController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Component[] Components;
        Components = gameObject.GetComponentsInChildren<MeshRenderer>();
        if (menuController.isShown == true & status != true)
        {
            Debug.Log("active true");
            //gameObject.SetActive(true);            
            foreach(MeshRenderer C in Components)
            {
                C.enabled = true;
            }
            status = true;
        }
        if(menuController.isShown == false & status != false)
        {
            Debug.Log("active false");
            foreach (MeshRenderer C in Components)
            {
                C.enabled = false;
            }
            //gameObject.SetActive(false);
            status = false;
        }
        
    }
}
