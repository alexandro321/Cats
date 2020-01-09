using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHome : MonoBehaviour
{
    public GameObject bedForCat;
    public GameObject bowlForCat;

    private GameObject bed;
    private GameObject bowl;

    private Vector3 bedPos;
    private Vector3 bowlPos;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(bedForCat, transform);
        Instantiate(bowlForCat, transform);
        bedPos = bedForCat.transform.position;
        bowlPos = bowlForCat.transform.position;
        bedPos.x = 0.01f;
        bedPos.z = 0.01f;
        bowlPos.x = -0.01f;
        bowlPos.z = -0.01f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
