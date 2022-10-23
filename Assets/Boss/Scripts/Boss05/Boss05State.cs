using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss05State : MonoBehaviour
{
    public static float dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            dir = -dir;
    }
}
