using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRise : MonoBehaviour
{
    public Animator animator = null;

/*    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            animator.SetTrigger("DoorRise");
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("DoorRise");
        }
    }
}
