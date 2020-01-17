using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeTime : MonoBehaviour
{
    public float startTime = 0;
    public float endTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (gameObject.activeSelf == true)
        {
            startTime += 0.15f * Time.deltaTime;
            if (startTime >= endTime)
            {
                gameObject.SetActive(!gameObject.activeSelf);
                startTime = 0;
            }
        }

    }
}
