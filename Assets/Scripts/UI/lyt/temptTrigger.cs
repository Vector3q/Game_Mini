using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temptTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameEvents.current.BossDie();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameEvents.current.PlayerDie();
        }
    }
}
