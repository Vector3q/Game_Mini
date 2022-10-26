using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fall_Explode : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" ||  collision.tag=="Player" ||collision.tag == "QDZX") 
            Destroy(gameObject);
    }
}
