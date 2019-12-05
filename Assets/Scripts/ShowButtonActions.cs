using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Debug.Log(gameObject.activeSelf);
        
    }
}
