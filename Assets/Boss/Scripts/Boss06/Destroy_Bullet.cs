using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    
    void Update()
    {
        StartCoroutine(destroy_self());
    }
    IEnumerator destroy_self()
    {
        yield return new WaitForSeconds(0.66f);
        Destroy(gameObject);
    }
}
