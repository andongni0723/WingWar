using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;
    }
}
