using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGeneratingPlanes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 0){
            gameObject.GetComponent<GoogleARCore.Examples.Common.DetectedPlaneGenerator>().enabled = false;
        }
        
    }
}
