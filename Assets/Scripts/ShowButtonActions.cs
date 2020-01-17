using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonActions : MonoBehaviour
{
    // Start is called before the first frame update
    public float startTime = 0;
    public float endTime = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.activeSelf == true){
            startTime += 0.3f * Time.deltaTime;
            if(startTime >= endTime){
                gameObject.SetActive(!gameObject.activeSelf);
                startTime = 0;
            }
        }

    }

    public void Change()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Debug.Log(gameObject.activeSelf);
        //startTime = 0;
        
    }
}
