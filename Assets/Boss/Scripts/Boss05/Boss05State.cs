using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss05State : MonoBehaviour
{
    public static float dir;
    public static int HP;
    public static bool isDead;

    void Start()
    {
        isDead = false;
        HP = 5;
        dir = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(HP);
        if (collision.tag == "Wall")
            dir = -dir;
    }
}
