using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss04State : MonoBehaviour
{
    static public float index;
    void Start()
    {
        index = Random.Range(-7, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
